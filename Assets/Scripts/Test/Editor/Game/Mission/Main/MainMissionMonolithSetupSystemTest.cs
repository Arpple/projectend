using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Test.GameTest.MissionTest
{
	public class MissionMonolithSetupSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new MissionBossMonolithSetupSystem(_contexts));
			_contexts.game.SetMainMission(MainMission.BossMonolith);

			var sp = _contexts.tile.CreateEntity();
			sp.AddMapPosition(1, 1);
			sp.AddSpawnpoint(-1);

			_contexts.game.SetPlayingOrder(new List<GameEntity>());
		}

		[Test]
		public void Execute_MissionEntityMonolithAdded_BossPlayerEntityCreated()
		{
			_systems.Execute();
			Assert.IsTrue(_contexts.game.isBossPlayer);

			var e = _contexts.unit.bossUnitEntity;
			Assert.IsTrue(e.owner.Entity.hasPlayer);
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

		[Test]
		public void Execute_MissionEntityMonolithAdded_BossPlayerAddToLastOfPlayingOrder()
		{
			_systems.Execute();

			var e = _contexts.unit.bossUnitEntity;
			var order = _contexts.game.playingOrder.PlayerOrder;
			Assert.IsTrue(order.Contains(e.owner.Entity));
			Assert.AreEqual(e.owner.Entity, order.Last());
		}
	}
}
