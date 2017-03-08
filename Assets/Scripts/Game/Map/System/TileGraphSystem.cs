using UnityEngine;
using Entitas;
using System.Linq;

namespace End
{
	public class TileGraphSystem : IInitializeSystem
	{
		readonly GameContext _context;

		public TileGraphSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			var tiles = _context.GetEntities(GameMatcher.Tile);
			foreach (var originTile in tiles)
			{
				originTile.AddTileGraph(null, null, null, null);
				foreach(var tile in tiles.Where(t => t.mapPosition.GetDistance(originTile.mapPosition) == 1))
				{
					if (tile.mapPosition.Y < originTile.mapPosition.Y)
						originTile.tileGraph.Down = tile;
					else if (tile.mapPosition.Y > originTile.mapPosition.Y)
						originTile.tileGraph.Up = tile;
					else if (tile.mapPosition.X > originTile.mapPosition.X)
						originTile.tileGraph.Right = tile;
					else
						originTile.tileGraph.Left = tile;
				}
			}
		}
	}
}
