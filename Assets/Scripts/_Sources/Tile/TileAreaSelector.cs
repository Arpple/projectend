using Entitas;
using System.Linq;

public static class TileAreaSelector
{
	public static TileEntity[] GetAllInRange(TileEntity center, int range, bool includeCenter = false)
	{
		var tiles = Contexts.sharedInstance.tile.GetEntities(TileMatcher.Tile)
			.Where(t => t.mapPosition.GetDistance(center.mapPosition) <= range);

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
						tile.tileGraph.Up,
						tile.tileGraph.Down,
						tile.tileGraph.Left,
						tile.tileGraph.Right,
				}.Where(t => t != null && t.isTileMovable && t.GetUnitOnTile() == null)
					.Except(selectedTiles).ToArray();

				newLeaf = newLeaf.Union(found).ToArray();
				selectedTiles = selectedTiles.Union(found).ToArray();
			}

			leaf = newLeaf;
		});

		if (!includeCenter)
		{
			selectedTiles = selectedTiles.Where(t => t != center && t != null).ToArray();
		}

		return selectedTiles;
	}
}
