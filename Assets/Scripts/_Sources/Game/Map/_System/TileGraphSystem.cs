using Entitas;
using System.Linq;

namespace Game
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
			var tiles = _context.GetEntities(GameMatcher.GameTile);
			foreach (var originTile in tiles)
			{
				originTile.AddGameTileGraph(null, null, null, null);
				foreach(var tile in tiles.Where(t => t.gameMapPosition.GetDistance(originTile.gameMapPosition) == 1))
				{
					if (tile.gameMapPosition.y < originTile.gameMapPosition.y)
						originTile.gameTileGraph.Down = tile;
					else if (tile.gameMapPosition.y > originTile.gameMapPosition.y)
						originTile.gameTileGraph.Up = tile;
					else if (tile.gameMapPosition.x > originTile.gameMapPosition.x)
						originTile.gameTileGraph.Right = tile;
					else
						originTile.gameTileGraph.Left = tile;
				}
			}
		}
	}
}
