using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileSetting : IndexDataList<Tile, TileData>
{
	public Map GameMap;
	public TileController TileControllerPrefabs;

	/// <summary>
	/// random weigth for tile resource charge index i equals i+1 charge
	/// </summary>
	[Tooltip("random weigth for tile resource charge index i equals i+1 charge")]
	public List<int> TileResourceChargeWeigth;
}