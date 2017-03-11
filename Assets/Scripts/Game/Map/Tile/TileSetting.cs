using Entitas.Unity.Blueprints;
using Entitas.Blueprints;
using System;

namespace End.Game
{
	[Serializable]
	public class TileSetting
	{
		const string BLUEPRINT_ENUM_PREFIX = "Tile_";

		public Blueprints TileBlueprints;

		public Blueprint GetTileBlueprint(Tile tile)
		{
			return TileBlueprints.GetBlueprint(BLUEPRINT_ENUM_PREFIX + tile.ToString());
		}
	}

}
