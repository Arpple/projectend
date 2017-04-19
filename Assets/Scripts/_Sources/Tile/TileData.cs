using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(menuName = "End/Tile", fileName = "new_tile.asset")]
public class TileData : EntityData, IIndexData<Tile>
{
	public Tile TileType;

	public Sprite Sprite;
	public bool IsWalkableOn;
	[Header("Resource")]
	public Resource Resource;
	public Sprite EmptyResourceSprite;

	public Tile GetIndex()
	{
		return TileType;
	}

	public bool IsIndexEquals(Tile index)
	{
		return TileType == index;
	}
}