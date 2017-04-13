using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace MapEditor
{
	public class TileBrushSystem : IInitializeSystem
	{
		public static TileBrushComponent TileBrush;

		readonly TileContext _context;

		public TileBrushSystem(Contexts contexts)
		{
			_context = contexts.tile;
		}

		public void Initialize()
		{
			SetupBrush();
			SetupTileBrushAction();
		}

		private void SetupBrush()
		{
			_context.SetMapEditorTileBrush(Tile.DeepForest, BrushAction.Tile, 1);
			TileBrush = _context.mapEditorTileBrush;
		}

		private void SetupTileBrushAction()
		{
			foreach(var e in _context.GetEntities(TileMatcher.Tile))
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

				tileEntity.RemoveSprite();
				tileEntity.ReplaceTile(brushTile);
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
