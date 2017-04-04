using Entitas;
using System.Linq;

namespace Game
{
	public static class AreaSelector
	{
		public static GameEntity[] GetAllInRange(GameEntity center, int range, bool includeCenter = false)
		{
			var tiles = Contexts.sharedInstance.game.GetEntities(GameMatcher.GameTile)
				.Where(t => t.gameMapPosition.GetDistance(center.gameMapPosition) <= range);

			return includeCenter ? tiles.ToArray() : tiles.Where(t => t != center).ToArray();
		}

		public static GameEntity[] GetMovePathInRange(GameEntity center, int range, bool includeCenter = false)
		{
			var selectedTiles = new GameEntity[0];
			var leaf = new GameEntity[] { center };

			range.Loop((i) =>
			{
				var newLeaf = new GameEntity[0];

				foreach (var tile in leaf)
				{
					var found = new GameEntity[]
					{
						tile.gameTileGraph.Up,
						tile.gameTileGraph.Down,
						tile.gameTileGraph.Left,
						tile.gameTileGraph.Right,
					}.Where(t => t != null && t.isGameTileMovable && t.GetUnitOnTile() == null)
						.Except(selectedTiles).ToArray();

					newLeaf = newLeaf.Union(found).ToArray();
					selectedTiles = selectedTiles.Union(found).ToArray();
				}

				leaf = newLeaf;
			});

			if(!includeCenter)
			{
				selectedTiles = selectedTiles.Where(t => t != center && t != null).ToArray();
			}

			return selectedTiles;
		}
	}

}
