using NUnit.Framework;

namespace Test.GameTest.MissionTest
{
	public class MainMissionMonolithSetupSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new MainMissionMonolithSetupSystem(_contexts));
			_contexts.game.SetMainMission(MainMission.BossMonolith);
			var sp = _contexts.tile.CreateEntity();
			sp.AddMapPosition(1, 1);
			sp.AddSpawnpoint(-1);
		}

		[Test]
		public void Execute_MissionEntityMonolithAdded_BossPlayerEntityCreated()
		{
			_systems.Execute();
			Assert.IsTrue(_contexts.game.isBossPlayer);
		}

		[Test]
		public void Execute_MissionEntityMonolithAdded_BossUnitEntityCreated()
		{
			_systems.Execute();
			Assert.IsTrue(_contexts.unit.hasBossUnit);

			var e = _contexts.unit.bossUnitEntity;
			Assert.AreEqual(Boss.Monolith, e.bossUnit.Type);
			Assert.AreEqual(1, e.mapPosition.x);
			Assert.AreEqual(1, e.mapPosition.y);
		}
	}
}
