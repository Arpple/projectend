using System.Collections.Generic;
using NUnit.Framework;

namespace Test.TurnTest
{
	public class RoundEndPlayingOrderReOrderingSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new RoundEndPlayingOrderReOrderingSystem(_contexts));
		}

		[Test]
		public void Execute_Round1_Nothing()
		{
			var p1 = _contexts.game.CreateEntity();
			var p2 = _contexts.game.CreateEntity();
			var order = _contexts.game.SetPlayingOrder(new List<GameEntity>() { p1, p2 }).playingOrder;

			_contexts.game.SetRound(1);
			_systems.Execute();

			Assert.AreEqual(p1, order.PlayerOrder[0]);
			Assert.AreEqual(p2, order.PlayerOrder[1]);
		}

		[Test]
		public void Execute_Round2_ReOrder()
		{
			var p1 = _contexts.game.CreateEntity();
			var p2 = _contexts.game.CreateEntity();
			var order = _contexts.game.SetPlayingOrder(new List<GameEntity>() { p1, p2 }).playingOrder;

			_contexts.game.SetRound(2);
			_systems.Execute();

			Assert.AreEqual(p1, order.PlayerOrder[1]);
			Assert.AreEqual(p2, order.PlayerOrder[0]);
		}
	}
}
