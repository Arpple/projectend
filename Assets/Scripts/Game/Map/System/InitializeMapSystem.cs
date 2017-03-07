﻿using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Blueprints;

namespace End
{
	public class InitializeMapSystem : IInitializeSystem
	{
		readonly GameContext _context;
		readonly MapSetting _setting;

		private Map _map;

		public InitializeMapSystem(Contexts contexts, Map map, MapSetting setting)
		{
			_context = contexts.game;
			_map = map;
			_setting = setting;
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
