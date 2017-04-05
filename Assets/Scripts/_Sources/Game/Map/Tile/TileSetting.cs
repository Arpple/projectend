using Entitas.Unity.Blueprints;
using Entitas.Blueprints;
using System;
using UnityEngine;

namespace Game
{
	[Serializable]
	public class TileSetting
	{
		const string BLUEPRINT_ENUM_PREFIX = "Tile_";
		const string SPRITE_ENUM_PREFIX = "Tile_";

		public JsonBlueprints TileBlueprints;

		public TileController TileController;
		public string PathToSpriteFolder;
		public string Container;

		public Blueprint GetTileBlueprint(Tile tile)
		{
			return TileBlueprints.GetBlueprint(BLUEPRINT_ENUM_PREFIX + tile.ToString());
		}

		public Sprite GetSprite(Tile tile)
		{
			var path = GetSpritePath(tile);
			var sprite = Resources.Load<Sprite>(path);
			if(sprite == null)
			{
				throw new MissingReferenceException("Missing Tile Sprite: " + path);
			}
			return sprite;
		}

        public Blueprint GetTileBlueprint(string tile) {
            return TileBlueprints.GetBlueprint(BLUEPRINT_ENUM_PREFIX + tile);
        }

		private string GetSpritePath(Tile tile)
		{
			return PathToSpriteFolder + "/" + SPRITE_ENUM_PREFIX + tile.ToString();
		}
    }

}
