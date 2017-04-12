using Entitas;
using UnityEngine.Assertions;

public class TileMapCreatingSystem : IInitializeSystem
{
	const string TILE_VIEW_CONTAINER = "View/Tile";

	private Map _map;
	private TileContext _context;

	public TileMapCreatingSystem(Contexts contexts, Map map)
	{
		Assert.IsNotNull(map);

		_context = contexts.tile;
		_map = map;
	}

	public void Initialize()
	{
		var spawnpointCounter = 1;

		_map.Heigth.Loop((y) =>
		{
			_map.Width.Loop((x) =>
			{
				var tile = _map.GetTile(x, y);
				var tileEntity = _context.CreateEntity();
				tileEntity.AddTile(tile);
				tileEntity.AddMapPosition(x, y);
				tileEntity.AddViewContainer(TILE_VIEW_CONTAINER);

				if (_map.IsSpawnPoint(x, y))
				{
					tileEntity.AddSpawnpoint(spawnpointCounter);
					spawnpointCounter++;
				}
			});
		});
	}
}