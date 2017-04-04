using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas.Blueprints;
using Game;

namespace MapEditor
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
			return context.CreateCollector(GameMatcher.GameTile, GroupEvent.Added);
		}

		protected override bool Filter (GameEntity entity)
		{
			return entity.hasGameTile;
		}

		public void Initialize()
		{
			_context.SetMapEditorTileBrush(Tile.DeepForest, BrushAction.Tile, 1);
			TileBrush = _context.mapEditorTileBrush;
		}

		protected override void Execute (List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				e.AddGameTileAction((x) => ReplaceTile(x));
			}
		}

		void ReplaceTile(GameEntity tileEntity)
		{
			var brush = _context.mapEditorTileBrush;
			var brushTile = brush.TileType;

			if (brush.Action == BrushAction.Tile)
			{
				if (tileEntity.gameTile.Type == brushTile) return;

				//remove old view
				var link = tileEntity.gameView.GameObject.GetEntityLink();
				link.Unlink();
				GameObject.Destroy(tileEntity.gameView.GameObject);

				var pos = tileEntity.gameMapPosition;
				tileEntity.RemoveAllComponents();

				tileEntity.ApplyBlueprint(_setting.GetTileBlueprint(brushTile));
				tileEntity.AddGameTile(brushTile);
				tileEntity.AddGameMapPosition(pos.x, pos.y);
			}
			else if (brush.Action == BrushAction.Spawnpoint)
			{
				var oldSpawnpoint = _context.GetEntities(GameMatcher.GameSpawnpoint)
					.Where(s => s.gameSpawnpoint.index == brush.SpawnpointIndex)
					.FirstOrDefault();

				if (oldSpawnpoint != null)
				{
					oldSpawnpoint.RemoveGameSpawnpoint();
				}

				if (tileEntity.hasGameSpawnpoint)
				{
					Debug.Log("Spawnpoint replaced " + tileEntity.gameSpawnpoint.index + "=>" + brush.SpawnpointIndex + " : " + tileEntity.gameMapPosition);
					tileEntity.ReplaceGameSpawnpoint(brush.SpawnpointIndex);
				}
				else
				{
					Debug.Log("Spawnpoint set " + brush.SpawnpointIndex + " : " + tileEntity.gameMapPosition);
					tileEntity.AddGameSpawnpoint(brush.SpawnpointIndex);
				}
			}
		}
	}
}
