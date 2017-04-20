using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using NUnit.Framework;

namespace Test.MissionTest
{
	public class MainMissionCompleteGameEndSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new MainMissionCompleteGameEndSystem(_contexts));
		}

		[Test]
		public void Execute_MainMissionCompleted_GameEndEventCreated()
		{
			_contexts.game.isMainMissionCompleted = true;

			_systems.Execute();

			var events = _contexts.gameEvent.GetEntities(GameEventMatcher.EventEndGame);

			Assert.AreEqual(1, events.Length);
		}
	}
}
