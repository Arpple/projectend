using Entitas;
using UnityEngine.Assertions;

public class TileMapCreatingSystem : IInitializeSystem
{
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
		var spawnpointIndex = 1;

		_map.Heigth.Loop((y) =>
		{
			_map.Width.Loop((x) =>
			{
				var tile = _map.GetTile(x, y);

				var entity = _context.CreateEntity();
				entity.AddTile(tile);
				entity.AddMapPosition(x, y);

				if (_map.IsSpawnPoint(x, y))
				{
					entity.AddSpawnpoint(spawnpointIndex);
					spawnpointIndex++;
				}
			});
		});
	}
}