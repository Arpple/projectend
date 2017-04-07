using Entitas;
using NUnit.Framework;
using UnityEngine;
using System.Linq;
using Game;

namespace Test.System
{
	public class TestTileMapCreatingSystem : ContextsTest
	{
		private Map _map;
		private MapSetting _setting;

		[SetUp]
		public void Init()
		{
			_map = ScriptableObject.CreateInstance<Map>();
			_setting = TestHelper.GetGameSetting().MapSetting;
		}

		[Test]
		public void GenerateTile()
		{
			_map.SetMap(5, 5, Tile.Grass);
			var system = new TileMapCreatingSystem(_contexts, _map, _setting);
			system.Initialize();

			var tileEntities = _contexts.tile.GetEntities(TileMatcher.GameTile);

			Assert.AreEqual(25, tileEntities.Length);
		}

		[Test]
		public void Spawpoint()
		{
			_map.SetMap(5, 5, Tile.Grass);
			_map.SetSpawnPoint(1, 1, 1);
			_map.Save();
			var system = new TileMapCreatingSystem(_contexts, _map, _setting);
			system.Initialize();

			var tileEntities = _contexts.tile.GetEntities(TileMatcher.GameTile);
			var spawnPoints = tileEntities.Where(t => t.hasGameSpawnpoint);

			Assert.AreEqual(1, spawnPoints.Count());
			Assert.AreEqual(1, spawnPoints.First().gameMapPosition.x);
			Assert.AreEqual(1, spawnPoints.First().gameMapPosition.y);
		}

	}
}
