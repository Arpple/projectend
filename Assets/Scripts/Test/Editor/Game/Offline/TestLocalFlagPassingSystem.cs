using UnityEngine;
using Game.Offline;
using NUnit.Framework;
using System.Collections.Generic;

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
		public void SetFlag()
		{
			var p1 = _contexts.game.CreateEntity();

			_contexts.game.SetGamePlayingOrder(new List<GameEntity>() { p1 });

			_contexts.game.SetGameRoundIndex(0);
			_systems.Execute();

			Assert.IsTrue(p1.isGameLocal);
		}

		[Test]
		public void PassFlag()
		{
			var p1 = _contexts.game.CreateEntity();
			p1.isGameLocal = true;

			var p2 = _contexts.game.CreateEntity();

			_contexts.game.SetGamePlayingOrder(new List<GameEntity>() { p1, p2 });

			_contexts.game.SetGameRoundIndex(1);
			_systems.Execute();

			Assert.IsFalse(p1.isGameLocal);
			Assert.IsTrue(p2.isGameLocal);
		}
	}
}

