﻿using Entitas;
using Entitas.Blueprints;
using UnityEngine.Assertions;

namespace End.Game
{
	public class CreateMapTileSystem : IInitializeSystem
	{
		const string TILE_VIEW_CONTAINER = "View/Tile";
		readonly GameContext _context;
		readonly MapSetting _setting;

		private Map _map;

		public CreateMapTileSystem(Contexts contexts, Map map, MapSetting setting)
		{
			Assert.IsNotNull(map);

			_context = contexts.game;
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
					tileEntity.AddTile(tile);
					tileEntity.AddMapPosition(x, y);
					tileEntity.AddViewContainer(TILE_VIEW_CONTAINER);

					if(_map.IsSpawnPoint(x, y))
					{
						tileEntity.AddSpawnpoint(spawnpointCounter);
						spawnpointCounter++;
					}
				});
			});
		}
	}
}