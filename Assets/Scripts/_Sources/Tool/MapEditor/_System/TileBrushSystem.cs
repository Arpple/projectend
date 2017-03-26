using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas.Blueprints;
using End.Game;

namespace End.MapEditor
{
	public class TileBrushSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		public static TileBrushComponent TileBrush;

		readonly GameContext _context;
		readonly TileSetting _setting;

		public TileBrushSystem(Contexts contexts, TileSetting setting)
			: base(contexts.game)
		{
			_context = contexts.game;
			_setting = setting;
		}

		protected override Collector<GameEntity> GetTrigger (IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Tile, GroupEvent.Added);
		}

		protected override bool Filter (GameEntity entity)
		{
			return entity.hasTile;
		}

		public void Initialize()
		{
			_context.SetTileBrush(Tile.DeepForest, BrushAction.Tile, 1);
			TileBrush = _context.tileBrush;
		}

		protected override void Execute (List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				e.AddTileAction(() => ReplaceTile(e));
			}
		}

		void ReplaceTile(GameEntity tileEntity)
		{
			var brush = _context.tileBrush;
			var brushTile = brush.TileType;

			if (brush.Action == BrushAction.Tile)
			{
				if (tileEntity.tile.Type == brushTile) return;

				//remove old view
				var link = tileEntity.view.GameObject.GetEntityLink();
				link.Unlink();
				GameObject.Destroy(tileEntity.view.GameObject);

				var pos = tileEntity.mapPosition;
				tileEntity.RemoveAllComponents();

				tileEntity.ApplyBlueprint(_setting.GetTileBlueprint(brushTile));
				tileEntity.AddTile(brushTile);
				tileEntity.AddMapPosition(pos.x, pos.y);
			}
			else if (brush.Action == BrushAction.Spawnpoint)
			{
				var oldSpawnpoint = _context.GetEntities(GameMatcher.Spawnpoint)
					.Where(s => s.spawnpoint.index == brush.SpawnpointIndex)
					.FirstOrDefault();

				if (oldSpawnpoint != null)
				{
					oldSpawnpoint.RemoveSpawnpoint();
				}

				if (tileEntity.hasSpawnpoint)
				{
					Debug.Log("Spawnpoint replaced " + tileEntity.spawnpoint.index + "=>" + brush.SpawnpointIndex + " : " + tileEntity.mapPosition);
					tileEntity.ReplaceSpawnpoint(brush.SpawnpointIndex);
				}
				else
				{
					Debug.Log("Spawnpoint set " + brush.SpawnpointIndex + " : " + tileEntity.mapPosition);
					tileEntity.AddSpawnpoint(brush.SpawnpointIndex);
				}
			}
		}
	}
}
