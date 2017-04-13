using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileSetting
{
	public Map GameMap;
	public TileController TileController;
	public List<TileData> TileDatas;

	/// <summary>
	/// random weigth for tile resource charge index i equals i+1 charge
	/// </summary>
	[Tooltip("random weigth for tile resource charge index i equals i+1 charge")]
	public List<int> TileResourceChargeWeigth;

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