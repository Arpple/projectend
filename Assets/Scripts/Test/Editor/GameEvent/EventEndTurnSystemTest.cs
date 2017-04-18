using System.Collections.Generic;
using NUnit.Framework;

namespace Test.EventTest
{
	public class EventEndTurnSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new EventEndTurnSystem(_contexts));
			var e = _contexts.gameEvent.CreateEntity();
			e.isEventEndTurn = true;

			var p1 = _contexts.game.CreateEntity();
			p1.isPlaying = true;
			var p2 = _contexts.game.CreateEntity();
			_contexts.game.SetPlayingOrder(new List<GameEntity>() { p1, p2 });
		}

		[Test]
		public void EndTurn()
		{
			var ct = _contexts.game;
			ct.SetTurn(1);
			ct.SetRound(1);
			ct.SetRoundIndex(0);

			_systems.Execute();

			Assert.AreEqual(2, ct.turn.Count);
			Assert.AreEqual(1, ct.round.Count);
			Assert.AreEqual(1, ct.roundIndex.Index);
		}

		[Test]
		public void EndRound()
		{
			var ct = _contexts.game;
			ct.SetTurn(1);
			ct.SetRound(1);
			ct.SetRoundIndex(1);

			_systems.Execute();

			Assert.AreEqual(2, ct.turn.Count);
			Assert.AreEqual(2, ct.round.Count);
			Assert.AreEqual(0, ct.roundIndex.Index);
		}
	}
}
