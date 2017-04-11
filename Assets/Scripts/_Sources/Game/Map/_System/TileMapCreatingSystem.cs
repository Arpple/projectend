using Entitas;
using Entitas.Blueprints;
using UnityEngine.Assertions;

namespace Game
{
	public class TileMapCreatingSystem : IInitializeSystem
	{
		const string TILE_VIEW_CONTAINER = "View/Tile";
		readonly TileEntityFactory _factory;
		readonly TileSetting _setting;

		private Map _map;

		public TileMapCreatingSystem(Contexts contexts, Map map, TileSetting setting)
		{
			Assert.IsNotNull(map);

			_factory = new TileEntityFactory(contexts.tile);
			_map = map;
			_setting = setting;
		}

		public void Initialize ()
		{
			var spawnpointCounter = 1;

			_map.Heigth.Loop((y) => {
				_map.Width.Loop((x) => {
					var tile = _map.GetTile(x, y);
					var tileEntity = _factory.CreateEntityWithComponents(_setting.GetTileData(tile));
					tileEntity.AddGameTile(tile);
					tileEntity.AddGameMapPosition(x, y);
					tileEntity.AddGameViewContainer(TILE_VIEW_CONTAINER);

					if(_map.IsSpawnPoint(x, y))
					{
						tileEntity.AddGameSpawnpoint(spawnpointCounter);
						spawnpointCounter++;
					}
				});
			});
		}
	}
}
