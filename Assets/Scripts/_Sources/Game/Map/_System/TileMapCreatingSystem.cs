using Entitas;
using Entitas.Blueprints;
using UnityEngine.Assertions;

namespace Game
{
	public class TileMapCreatingSystem : IInitializeSystem
	{
		const string TILE_VIEW_CONTAINER = "View/Tile";
		readonly TileContext _context;
		readonly MapSetting _setting;

		private Map _map;

		public TileMapCreatingSystem(Contexts contexts, Map map, MapSetting setting)
		{
			Assert.IsNotNull(map);

			_context = contexts.tile;
			_map = map;
			_setting = setting;
		}

		public void Initialize ()
		{
			var tileSetting = _setting.TileSetting;
			var spawnpointCounter = 1;

			_map.Heigth.Loop((y) => {
				_map.Width.Loop((x) => {
					var tileEntity = _context.CreateEntity();
					var tile = _map.GetTile(x, y);

					tileEntity.ApplyBlueprint(tileSetting.GetTileBlueprint(tile));
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
