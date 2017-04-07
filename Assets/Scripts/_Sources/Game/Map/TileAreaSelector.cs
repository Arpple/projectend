using Entitas;
using System.Linq;

namespace Game
{
	public static class TileAreaSelector
	{
		public static TileEntity[] GetAllInRange(TileEntity center, int range, bool includeCenter = false)
		{
			var tiles = Contexts.sharedInstance.tile.GetEntities(TileMatcher.GameTile)
				.Where(t => t.gameMapPosition.GetDistance(center.gameMapPosition) <= range);

			return includeCenter ? tiles.ToArray() : tiles.Where(t => t != center).ToArray();
		}

		public static TileEntity[] GetMovePathInRange(TileEntity center, int range, bool includeCenter = false)
		{
			var selectedTiles = new TileEntity[0];
			var leaf = new[] { center };

			range.Loop((i) =>
			{
				var newLeaf = new TileEntity[0];

				foreach (var tile in leaf)
				{
					var found = new[]
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
