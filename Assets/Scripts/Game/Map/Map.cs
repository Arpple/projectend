using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace End
{
	public class Map : ScriptableObject
	{
		[Serializable]
		private class MapRow
		{
			private int[] _tiles;

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

		private MapRow[] _rows;

		public int Width
		{
			get { return _rows[0].Width; }
		}

		public int Heigth
		{
			get { return _rows.Length; }
		}

		/// <summary>
		/// Sets the data for map.
		/// </summary>
		/// <returns>The map.</returns>
		/// <param name="width">Width.</param>
		/// <param name="heigth">Heigth.</param>
		public Map SetMap(int width, int heigth, Tile defaultTile = Tile.None)
		{
			_rows = new MapRow[heigth];
			heigth.Loop(
				(i) => _rows[i] = new MapRow(width, defaultTile)
			);

			return this;
		}

		public Tile GetTile(int x, int y)
		{
			Assert.IsTrue(
				x >= 0 && x < Width
				&& y >= 0 && y < Heigth
			);

			return _rows[y].GetTile(x);
		}

		public Tile GetTile(MapPositionComponent mapPosition)
		{
			return GetTile(mapPosition.X, mapPosition.Y);
		}

		public Map SetTile(int x, int y, Tile tile)
		{
			Assert.IsTrue(
				x >= 0 && x < Width
				&& y >= 0 && y < Heigth
			);

			_rows[y].SetTile(x, tile);

			return this;
		}

		public Map SetTile(MapPositionComponent mapPosition, Tile tile)
		{
			return SetTile(mapPosition.X, mapPosition.Y, tile);
		}
	}	
}

