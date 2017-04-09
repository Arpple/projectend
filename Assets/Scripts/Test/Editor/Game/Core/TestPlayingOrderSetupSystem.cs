﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;
using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestPlayingOrderSetupSystem : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new PlayingOrderSetupSystem(_contexts));
		}

		[Test]
		public void Setup()
		{
			var p1 = CreatePlayerEntity(1);
			var p2 = CreatePlayerEntity(2);

			_systems.Initialize();
			var order = _contexts.game.gamePlayingOrder;

			Assert.IsNotNull(order);
			Assert.AreEqual(2, order.PlayerOrder.Count);
			Assert.AreEqual(p1, order.PlayerOrder[0]);
			Assert.AreEqual(p2, order.PlayerOrder[1]);
		}
	}
}
