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

		private CacheList<Tile, TileData> _cacheData;

		public TileSetting()
		{
			_cacheData = new CacheList<Tile, TileData>();
		}

		public TileData GetTileData(Tile tile)
		{
			var data = _cacheData.Get(tile,(t) => TileDatas.FirstOrDefault(d => d.TileType == t));
			if (data == null) throw new MissingReferenceException("Tile data not found : " + tile.ToString());
			return data;
		}

		private string GetSpritePath(Tile tile)
		{
			return PathToSpriteFolder + "/" + SPRITE_ENUM_PREFIX + tile.ToString();
		}
    }

}
