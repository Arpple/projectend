using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "End/Tile", fileName = "new_tile.asset")]
public class TileData : EntityData
{
	public Tile TileType;

	public Sprite Sprite;
	public bool IsWalkableOn;
}