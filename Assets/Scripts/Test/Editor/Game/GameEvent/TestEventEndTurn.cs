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
		}

		[Test]
		public void PassPlayingFlag()
		{
			var p1 = _contexts.game.CreateEntity();
			p1.isGamePlaying = true;
			var p2 = _contexts.game.CreateEntity();

			var order = _contexts.game.SetGamePlayingOrder(new List<GameEntity>() { p1, p2 });
			order.gamePlayingOrder.Initialize();

			_systems.Execute();

			Assert.AreEqual(p2, order.gamePlayingOrder.CurrentPlayer);
			Assert.IsTrue(p2.isGamePlaying);
		}
	}
}
