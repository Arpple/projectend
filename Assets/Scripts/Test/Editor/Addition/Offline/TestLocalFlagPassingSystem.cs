using System.Collections.Generic;
using NUnit.Framework;
using Offline;

namespace Test.AdditionTest.OfflineTest
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

			_contexts.game.SetPlayingOrder(new List<GameEntity>() { p1 });

			_contexts.game.SetRoundIndex(0);
			_systems.Execute();

			Assert.IsTrue(p1.isLocal);
		}

		[Test]
		public void PassFlag()
		{
			var p1 = _contexts.game.CreateEntity();
			p1.isLocal = true;

			var p2 = _contexts.game.CreateEntity();

			_contexts.game.SetPlayingOrder(new List<GameEntity>() { p1, p2 });

			_contexts.game.SetRoundIndex(1);
			_systems.Execute();

			Assert.IsFalse(p1.isLocal);
			Assert.IsTrue(p2.isLocal);
		}
	}
}

