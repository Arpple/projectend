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

		[Serializable]
		private class SpawnPoint
		{
			public int x;
			public int y;

			public SpawnPoint(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}

		private MapRow[] _rows;
		private Dictionary<int, SpawnPoint> _spawnPoints;

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

			_spawnPoints = new Dictionary<int, SpawnPoint>();

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
			return GetTile(mapPosition.x, mapPosition.y);
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
			return SetTile(mapPosition.x, mapPosition.y, tile);
		}

		public Map SetSpawnPoint(int index, int x, int y)
		{
			if(_spawnPoints.ContainsKey(index))
			{
				var s = _spawnPoints[index];
				s.x = x;
				s.y = y;
			}
			else
			{
				_spawnPoints.Add(index, new SpawnPoint(x, y));
			}

			return this;
		}

		public Map SetSpawnPoint(int index, MapPositionComponent pos)
		{
			return SetSpawnPoint(index, pos.x, pos.y);
		}
	}	
}

