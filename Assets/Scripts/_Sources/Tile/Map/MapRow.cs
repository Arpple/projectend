using System;
using UnityEngine;
using UnityEngine.Assertions;

public partial class Map : ScriptableObject
{
	[Serializable]
	private class MapRow
	{
		[SerializeField] private int[] _tiles;

		public int Width
		{
			get { return _tiles.Length; }
		}

		public MapRow(int rowSize, Tile defaultTile = Tile.None)
		{
			_tiles = new int[rowSize];
			rowSize.Loop(
				(i) => _tiles[i] = (int)defaultTile
			);
		}

		public Tile GetTile(int x)
		{
			Assert.IsTrue(x >= 0 && x < Width);
			return (Tile)_tiles[x];
		}

		public void SetTile(int x, Tile tile)
		{
			Assert.IsTrue(x >= 0 && x < Width);
			_tiles[x] = (int)tile;
		}
	}
}
