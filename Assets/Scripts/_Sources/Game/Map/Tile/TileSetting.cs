using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[Serializable]
	public class TileSetting
	{
		const string BLUEPRINT_ENUM_PREFIX = "Tile_";
		const string SPRITE_ENUM_PREFIX = "Tile_";

		public List<TileData> TileDatas;

		public TileController TileController;
		public string PathToSpriteFolder;
		public string Container;

		public TileData GetTileData(Tile tile)
		{
			var data = TileDatas.FirstOrDefault(t => t.TileType == tile);
			if (data == null) throw new MissingReferenceException("Tile data not found : " + tile.ToString());
			return data;
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

		private string GetSpritePath(Tile tile)
		{
			return PathToSpriteFolder + "/" + SPRITE_ENUM_PREFIX + tile.ToString();
		}
    }

}
