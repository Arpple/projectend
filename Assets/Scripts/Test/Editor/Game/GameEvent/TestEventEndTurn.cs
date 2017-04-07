using UnityEngine;
using NUnit.Framework;
using Game;
using System.Collections.Generic;

namespace Test.Event
{
	public class TestEventEndTurn : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new EventEndTurnSystem(_contexts));
			var e = _contexts.gameEvent.CreateEntity();
			e.isGameEventEndTurn = true;

			var p1 = _contexts.game.CreateEntity();
			p1.isGamePlaying = true;
			var p2 = _contexts.game.CreateEntity();
			_contexts.game.SetGamePlayingOrder(new List<GameEntity>() { p1, p2 });
		}

		[Test]
		public void EndTurn()
		{
			var ct = _contexts.game;
			ct.SetGameTurn(1);
			ct.SetGameRound(1);
			ct.SetGameRoundIndex(0);

			_systems.Execute();

			Assert.AreEqual(2, ct.gameTurn.Count);
			Assert.AreEqual(1, ct.gameRound.Count);
			Assert.AreEqual(1, ct.gameRoundIndex.Index);
		}

		[Test]
		public void EndRound()
		{
			var ct = _contexts.game;
			ct.SetGameTurn(1);
			ct.SetGameRound(1);
			ct.SetGameRoundIndex(1);

			_systems.Execute();

			Assert.AreEqual(2, ct.gameTurn.Count);
			Assert.AreEqual(2, ct.gameRound.Count);
			Assert.AreEqual(0, ct.gameRoundIndex.Index);
		}
	}
}
