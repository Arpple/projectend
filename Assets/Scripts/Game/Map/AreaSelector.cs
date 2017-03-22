using Entitas;
using System.Linq;

namespace End.Game
{
	public static class AreaSelector
	{
		public static GameEntity[] GetAllInRange(GameEntity center, int range, bool includeCenter = false)
		{
			var tiles = Contexts.sharedInstance.game.GetEntities(GameMatcher.Tile)
				.Where(t => t.mapPosition.GetDistance(center.mapPosition) <= range);

			return includeCenter ? tiles.ToArray() : tiles.Where(t => t != center).ToArray();
		}

		public static GameEntity[] GetMovePathInRange(GameEntity center, int range, bool includeCenter = false)
		{
			var tiles = Contexts.sharedInstance.game.GetEntities(GameMatcher.Tile);

			var selectedTiles = new GameEntity[0];
			var leaf = new GameEntity[] { center };

			range.Loop((i) =>
			{
				var newLeaf = new GameEntity[0];

				foreach (var tile in leaf)
				{
					var found = new GameEntity[]
					{
						tile.tileGraph.Up,
						tile.tileGraph.Down,
						tile.tileGraph.Left,
						tile.tileGraph.Right,
					}.Where(t => t != null && t.isTileMovable && t.GetUnitOnTile() == null)
						.Except(selectedTiles).ToArray();

					newLeaf = newLeaf.Union(found).ToArray();
					selectedTiles = selectedTiles.Union(found).Where(t => t != null).ToArray();
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
