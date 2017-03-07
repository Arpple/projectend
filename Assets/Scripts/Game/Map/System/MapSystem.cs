using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Blueprints;

namespace End
{
	public class MapSystem : IInitializeSystem
	{
		private static MapSystem _instance;

		readonly GameContext _context;
		readonly MapSetting _setting;

		private Map _map;

		public MapSystem(Contexts contexts, Map map, MapSetting setting)
		{
			_context = contexts.game;
			_map = map;
			_setting = setting;
			_instance = this;
		}

		public void Initialize ()
		{
			var tileSetting = _setting.TileSetting;

			_map.Heigth.Loop((y) => {
				_map.Width.Loop((x) => {
					var tileEntity = _context.CreateEntity();
					var tile = _map.GetTile(x, y);

					tileEntity.ApplyBlueprint(tileSetting.GetTileBlueprint(tile));
					tileEntity.AddTile(tile);
					tileEntity.AddMapPosition(x, y);
				});
			});
		}
	}
}
