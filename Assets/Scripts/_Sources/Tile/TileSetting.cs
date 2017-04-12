using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileSetting
{
	const string BLUEPRINT_ENUM_PREFIX = "Tile_";
	const string SPRITE_ENUM_PREFIX = "Tile_";

	public Map GameMap;
	public List<TileData> TileDatas;
	public TileController TileController;

	private CacheList<Tile, TileData> _cacheData;

	public TileSetting()
	{
		_cacheData = new CacheList<Tile, TileData>();
	}

	public TileData GetTileData(Tile tile)
	{
		var data = _cacheData.Get(tile, (t) => TileDatas.FirstOrDefault(d => d.TileType == t));
		if (data == null) throw new MissingReferenceException("Tile data not found : " + tile.ToString());
		return data;
	}
}