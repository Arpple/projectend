using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas.Unity.Blueprints;
using Entitas.Blueprints;
using System.Linq;
using System;
using UnityEngine.Assertions;

namespace End
{
	public class TileSetting : ScriptableObject
	{
		const string BLUEPRINT_PREFIX = "Tile_";

		public Blueprints TileBlueprints;
		public string ViewRootPath;
		public GameObject BaseTileObject;

		public Blueprint GetTileBlueprint(Tile tile)
		{
			return TileBlueprints.GetBlueprint(BLUEPRINT_PREFIX + tile.ToString());
		}
	}

}
