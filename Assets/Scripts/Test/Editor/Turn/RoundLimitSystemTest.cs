using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using NUnit.Framework;

namespace Test.TurnTest
{
	public class RoundLimitSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new RoundLimitSystem(_contexts));
		}

		[Test]
		public void Execute_RoundNotExceedLimit_NoGameEndEvent()
		{
			_contexts.game.SetRoundLimit(10);
			_contexts.game.SetRound(1);

			_systems.Execute();

			var events = _contexts.gameEvent.GetEntities(GameEventMatcher.EventEndGame);

			Assert.AreEqual(0, events.Length);
		}

		[Test]
		public void Execute_RoundExceedLimit_GameEndEventCreate()
		{
			_contexts.game.SetRoundLimit(10);
			_contexts.game.SetRound(10);

			_systems.Execute();

			var events = _contexts.gameEvent.GetEntities(GameEventMatcher.EventEndGame);

			Assert.AreEqual(1, events.Length);
		}
	}
}
