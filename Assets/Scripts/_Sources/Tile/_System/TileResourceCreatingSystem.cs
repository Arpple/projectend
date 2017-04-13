using Entitas;

public class TileResourceCreatingSystem : IInitializeSystem
{
	private TileContext _context;

	public TileResourceCreatingSystem(Contexts contexts)
	{
		_context = contexts.tile;
	}

	public void Initialize()
	{
		foreach (var tile in _context.GetEntities(TileMatcher.Tile))
		{
			AddTileResource(tile);
		}
	}

	private void AddTileResource(TileEntity entity)
	{
		switch(entity.tile.Type)
		{
			case Tile.DeepForest:
				entity.AddResource(Resource.Wood);
				break;

			case Tile.Mountain:
				entity.AddResource(Resource.Coal);
				break;

			case Tile.Water:
				entity.AddResource(Resource.Water);
				break;
		}
	}
}