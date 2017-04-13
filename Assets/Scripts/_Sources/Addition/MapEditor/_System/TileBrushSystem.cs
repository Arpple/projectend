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
			_context.SetMapEditorTileBrush(Tile.DeepForest, MapEditor.BrushAction.Tile, 1);
			TileBrush = _context.mapEditorTileBrush;
		}

		private void SetupTileBrushAction()
		{
			foreach(var e in _context.GetEntities(TileMatcher.Tile))
			{
				e.AddTileAction(() => BrushAction(e));
			}
		}

		void BrushAction(TileEntity entity)
		{
			var brush = _context.mapEditorTileBrush;
			var brushTile = brush.TileType;

			if (brush.Action == MapEditor.BrushAction.Tile)
			{
				if (entity.tile.Type == brushTile) return;
				ReplaceTileType(entity, brushTile);
			}
			else if (brush.Action == MapEditor.BrushAction.Spawnpoint)
			{
				SetTileSpawnpoint(entity, brush.SpawnpointIndex);
			}
		}

		private void ReplaceTileType(TileEntity entity, Tile type)
		{
			entity.RemoveSprite();
			entity.ReplaceTile(type);
		}

		private void SetTileSpawnpoint(TileEntity entity, int index)
		{
			RemoveMapSpawnpoint(index);

			if (entity.hasSpawnpoint)
			{
				Debug.Log("Spawnpoint replaced " + entity.spawnpoint.index + "=>" + index + " : " + entity.mapPosition);
				entity.ReplaceSpawnpoint(index);
			}
			else
			{
				Debug.Log("Spawnpoint set " + index + " : " + entity.mapPosition);
				entity.AddSpawnpoint(index);
			}
		}

		private void RemoveMapSpawnpoint(int index)
		{
			var spawnpoint = _context.GetEntitiesWithSpawnpoint(index)
					.FirstOrDefault();

			if (spawnpoint != null)
			{
				Debug.Log("Spawnpoint removed " + index + " : " + spawnpoint.mapPosition);
				spawnpoint.RemoveSpawnpoint();
			}
		}
	}
}
