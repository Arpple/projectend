using UnityEngine;
using System.Collections;

namespace Game
{
	[CreateAssetMenu(menuName = "End/Tile", fileName = "new_tile.asset")]
	public class TileData : ScriptableObject
	{
		public Tile TileType;

		public Sprite Sprite;
		public bool IsWalkableOn;
	}
}
