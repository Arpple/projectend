using System.Linq;
using Entitas;
using NUnit.Framework;
using UnityEngine;


namespace Test.TileTest
{
	public class TestTileMapCreatingSystem : ContextsTest
	{
		private Map _map;
		private TileSetting _setting;

		[SetUp]
		public void Init()
		{
			_map = ScriptableObject.CreateInstance<Map>();
			_setting = TestHelper.GetGameSetting().MapSetting.TileSetting;
		}

		[Test]
		public void GenerateTile()
		{
			_map.SetMap(5, 5, Tile.Grass);
			var system = new TileMapCreatingSystem(_contexts, _map, _setting);
			system.Initialize();

			var tileEntities = _contexts.tile.GetEntities(TileMatcher.Tile);

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

			var tileEntities = _contexts.tile.GetEntities(TileMatcher.Tile);
			var spawnPoints = tileEntities.Where(t => t.hasSpawnpoint);

			Assert.AreEqual(1, spawnPoints.Count());
			Assert.AreEqual(1, spawnPoints.First().mapPosition.x);
			Assert.AreEqual(1, spawnPoints.First().mapPosition.y);
		}

	}
}
