using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas.Blueprints;
using Game;

namespace MapEditor
{
	public class TileBrushSystem : ReactiveSystem<TileEntity>, IInitializeSystem
	{
		public static TileBrushComponent TileBrush;

		readonly TileEntityFactory _factory;
		readonly TileContext _context;
		readonly TileSetting _setting;

		public TileBrushSystem(Contexts contexts, TileSetting setting)
			: base(contexts.tile)
		{
			_context = contexts.tile;
			_setting = setting;
			_factory = new TileEntityFactory(_context); ;
		}

		protected override Collector<TileEntity> GetTrigger (IContext<TileEntity> context)
		{
			return context.CreateCollector(TileMatcher.GameTile, GroupEvent.Added);
		}

		protected override bool Filter (TileEntity entity)
		{
			return entity.hasGameTile;
		}

		public void Initialize()
		{
			_context.SetMapEditorTileBrush(Tile.DeepForest, BrushAction.Tile, 1);
			TileBrush = _context.mapEditorTileBrush;
		}

		protected override void Execute (List<TileEntity> entities)
		{
			foreach(var e in entities)
			{
				e.AddGameTileAction(() => ReplaceTile(e));
			}
		}

		void ReplaceTile(TileEntity tileEntity)
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

				_factory.AddComponents(tileEntity, _setting.GetTileData(brushTile));
				tileEntity.AddGameTile(brushTile);
				tileEntity.AddGameMapPosition(pos.x, pos.y);
			}
			else if (brush.Action == BrushAction.Spawnpoint)
			{
				var oldSpawnpoint = _context.GetEntities(TileMatcher.GameSpawnpoint)
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
