using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


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
			return context.CreateCollector(TileMatcher.Tile, GroupEvent.Added);
		}

		protected override bool Filter (TileEntity entity)
		{
			return entity.hasTile;
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
				e.AddTileAction(() => ReplaceTile(e));
			}
		}

		void ReplaceTile(TileEntity tileEntity)
		{
			var brush = _context.mapEditorTileBrush;
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

				_factory.AddComponents(tileEntity, _setting.GetTileData(brushTile));
				tileEntity.AddTile(brushTile);
				tileEntity.AddMapPosition(pos.x, pos.y);
			}
			else if (brush.Action == BrushAction.Spawnpoint)
			{
				var oldSpawnpoint = _context.GetEntities(TileMatcher.Spawnpoint)
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
