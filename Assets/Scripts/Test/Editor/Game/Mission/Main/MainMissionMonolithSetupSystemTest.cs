﻿using NUnit.Framework;

namespace Test.GameTest.MissionTest
{
	public class MainMissionMonolithSetupSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new MainMissionMonolithSetupSystem(_contexts));
			_contexts.game.SetMainMission(MainMission.BossMonolith);
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
			Assert.AreEqual(Boss.Monolith, _contexts.unit.bossUnitEntity.bossUnit.Type);
		}
	}
}
