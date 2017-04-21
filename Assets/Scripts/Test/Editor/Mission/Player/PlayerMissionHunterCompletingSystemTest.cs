using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Test.MissionTest
{
	public class PlayerMissionHunterCompletingSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new PlayerMissionHunterCompletingSystem(_contexts));
		}

		[Test]
		public void Execute_TargetDead_HunterMissionComplete()
		{
			var targetPlayer = _contexts.game.CreateEntity();
			var target = _contexts.unit.CreateEntity();
			target.AddOwner(targetPlayer);
			target.isDead = true;

			var hunter = _contexts.game.CreateEntity();
			hunter.AddPlayerMission(PlayerMission.Hunter);
			hunter.AddPlayerMissionTarget(targetPlayer);

			_systems.Execute();

			Assert.IsTrue(hunter.isPlayerMissionCompleted);
		}
	}
}
