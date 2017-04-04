using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Test.System
{
	public class TestPlayingOrderSystem : ContextsTest
	{
		[Test]
		public void CycleTurnLogic()
		{
			_contexts.game.SetPlayingOrder(new List<GameEntity>
			{
				TestHelper.CreatePlayerEntity(_contexts.game, 1),
				TestHelper.CreatePlayerEntity(_contexts.game, 2),
				TestHelper.CreatePlayerEntity(_contexts.game, 3),
				TestHelper.CreatePlayerEntity(_contexts.game, 4),
			});
			var order = _contexts.game.playingOrder;
			Assert.AreEqual(1, order.GetNextPlayerEntity().player.PlayerId);
			Assert.AreEqual(2, order.GetNextPlayerEntity().player.PlayerId);
			Assert.AreEqual(3, order.GetNextPlayerEntity().player.PlayerId);
			Assert.AreEqual(4, order.GetNextPlayerEntity().player.PlayerId);
			Assert.AreEqual(2, order.GetNextPlayerEntity().player.PlayerId);
			Assert.AreEqual(3, order.GetNextPlayerEntity().player.PlayerId);
			Assert.AreEqual(4, order.GetNextPlayerEntity().player.PlayerId);
			Assert.AreEqual(1, order.GetNextPlayerEntity().player.PlayerId);
			Assert.AreEqual(3, order.GetNextPlayerEntity().player.PlayerId);
		}

		[Test]
		public void SystemInitialize()
		{
			4.Loop((i) =>
			{
				TestHelper.CreatePlayerEntity(_contexts.game, i + 1);
			});

			var system = new Game.PlayingOrderSystem(_contexts);

			system.Initialize();

			var order = _contexts.game.playingOrder.PlayerOrder;

			4.Loop(i => Assert.AreEqual(i + 1, order[i].player.PlayerId));
		}
	
	}

}
