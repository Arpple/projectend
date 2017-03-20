using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace End.Test
{
	public class TestPlayingOrderSystem
	{
		private Contexts _contexts;
		private GameObject _playerObject;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			_playerObject = Resources.Load<GameObject>("Game/Core/_Prefabs/Player");
		}

		[Test]
		public void CycleTurnLogic()
		{
			_contexts.game.SetPlayingOrder(new List<short> { 1, 2, 3, 4 });
			var order = _contexts.game.playingOrder;
			Assert.AreEqual(1, order.NextPlayerId());
			Assert.AreEqual(2, order.NextPlayerId());
			Assert.AreEqual(3, order.NextPlayerId());
			Assert.AreEqual(4, order.NextPlayerId());
			Assert.AreEqual(2, order.NextPlayerId());
			Assert.AreEqual(3, order.NextPlayerId());
			Assert.AreEqual(4, order.NextPlayerId());
			Assert.AreEqual(1, order.NextPlayerId());
			Assert.AreEqual(3, order.NextPlayerId());
		}

		[Test]
		public void SystemInitialize()
		{
			var players = new List<Player>();

			4.Loop((i) =>
			{
				var p = Object.Instantiate(_playerObject).GetComponent<Player>();
				p.PlayerId = (short)(i + 1);
				players.Add(p);
			});

			var system = new Game.PlayingOrderSystem(_contexts, players);

			system.Initialize();

			var order = _contexts.game.playingOrder.PlayerIdOrder;

			4.Loop(i => Assert.AreEqual((short)(i + 1), order[i]));
		}
	
	}

}
