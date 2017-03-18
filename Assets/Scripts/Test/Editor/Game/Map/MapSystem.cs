using Entitas;
using NUnit.Framework;
using UnityEngine;
using System.Linq;
using End.Game;

namespace End.Test
{
	public class TestMapSystem
	{
		private Contexts _contexts;
		private Map _map;
		private MapSetting _setting;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			_map = ScriptableObject.CreateInstance<Map>();
			_setting = TestHelper.GetGameSetting().MapSetting;
		}

		[Test]
		public void GenerateTile()
		{
			_map.SetMap(5, 5, Tile.Grass);
			var system = new MapSystem(_contexts, _map, _setting);
			system.Initialize();

			var tileEntities = _contexts.game.GetEntities(GameMatcher.Tile);

			Assert.AreEqual(25, tileEntities.Length);
		}

		[Test]
		public void Spawpoint()
		{
			_map.SetMap(5, 5, Tile.Grass);
			_map.SetSpawnPoint(1, 1, 1);
			_map.Save();
			var system = new MapSystem(_contexts, _map, _setting);
			system.Initialize();

			var tileEntities = _contexts.game.GetEntities(GameMatcher.Tile);
			var spawnPoints = tileEntities.Where(t => t.hasSpawnpoint);

			Assert.AreEqual(1, spawnPoints.Count());
			Assert.AreEqual(1, spawnPoints.First().mapPosition.x);
			Assert.AreEqual(1, spawnPoints.First().mapPosition.y);
		}

	}
}
