﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public partial class Map : ScriptableObject
{

	[SerializeField] private MapRow[] _rows;
	[SerializeField] private List<SpawnPoint> _spawnPoints;
	[SerializeField] private SpawnPoint _bossSpawnpoint;

	[NonSerialized] private Dictionary<int, SpawnPoint> _indexedSpawnpoints;

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

		return Load();
	}

	public Map Load()
	{
		_spawnPoints = _spawnPoints ?? new List<SpawnPoint>();
		_indexedSpawnpoints = new Dictionary<int, SpawnPoint>();
		_spawnPoints.Count.Loop(
			(i) => _indexedSpawnpoints.Add(i + 1, _spawnPoints[i])
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
		if(index == -1)
		{
			_bossSpawnpoint = new SpawnPoint(x, y);
			return this;
		}

		if (_indexedSpawnpoints == null)
		{
			Debug.Log("_indexedSpawnpoints==null");
			_indexedSpawnpoints = new Dictionary<int, SpawnPoint>();
		}
		if (_indexedSpawnpoints.ContainsKey(index))
		{
			_indexedSpawnpoints[index].x = x;
			_indexedSpawnpoints[index].y = y;
		}
		else
		{
			_indexedSpawnpoints.Add(index, new SpawnPoint(x, y));
		}

		return this;
	}

	public Map SetSpawnPoint(int index, MapPositionComponent pos)
	{
		return SetSpawnPoint(index, pos.x, pos.y);
	}

	public bool IsSpawnPoint(int x, int y)
	{
		foreach (var sp in _spawnPoints)
		{
			if (sp.x == x && sp.y == y)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasBossSpawnpoint()
	{
		return _bossSpawnpoint != null;
	}

	public bool IsBossSpawnpoint(int x, int y)
	{
		return _bossSpawnpoint.x == x && _bossSpawnpoint.y == y;
	}

	public Map Save()
	{
		_spawnPoints = _indexedSpawnpoints.Values.Where(s => s != null).ToList();
		//Debug.Log("_spanwPoin");
		return this;
	}
}
