using Entitas;
using System.Linq;

namespace End.Game
{
	public class CreateTileGraphSystem : IInitializeSystem
	{
		readonly GameContext _context;

		public CreateTileGraphSystem(Contexts contexts)
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
					if (tile.mapPosition.y < originTile.mapPosition.y)
						originTile.tileGraph.Down = tile;
					else if (tile.mapPosition.y > originTile.mapPosition.y)
						originTile.tileGraph.Up = tile;
					else if (tile.mapPosition.x > originTile.mapPosition.x)
						originTile.tileGraph.Right = tile;
					else
						originTile.tileGraph.Left = tile;
				}
			}
		}
	}
}
