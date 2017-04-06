using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Game.Offline;
using System.Collections.Generic;
using Game;

namespace Test.System
{
	public class TestLocalFlagPassingSystem : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new LocalFlagPassingSystem(_contexts));
		}

		[Test]
		public void EndTurn()
		{
			var p1 = _contexts.game.CreateEntity();
			p1.isGameLocal = true;

			var p2 = _contexts.game.CreateEntity();

			var e = _contexts.gameEvent.CreateEntity();
			e.isGameEventEndTurn = true;

			var order = _contexts.game.SetGamePlayingOrder(new List<GameEntity>() { p1, p2 });
			order.gamePlayingOrder.Initialize();
			order.gamePlayingOrder.GetNextPlayerEntity();

			_systems.Execute();

			Assert.IsTrue(p2.isGameLocal);
		}
	}
}
