using System.Linq;
using Entitas;

public class TileGraphCreatingSystem : IInitializeSystem
{
	readonly TileContext _context;

	public TileGraphCreatingSystem(Contexts contexts)
	{
		_context = contexts.tile;
	}

	public void Initialize()
	{
		var tiles = _context.GetEntities(TileMatcher.Tile);
		foreach (var originTile in tiles)
		{
			originTile.AddTileGraph(null, null, null, null);
			foreach (var tile in tiles.Where(t => t.mapPosition.GetDistance(originTile.mapPosition) == 1))
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