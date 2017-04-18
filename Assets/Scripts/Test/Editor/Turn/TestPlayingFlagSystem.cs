using System.Collections.Generic;
using NUnit.Framework;

namespace Test.TurnTest
{
	public class TestPlayingFlagSystem : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new PlayingFlagSystem(_contexts));
		}		
	
		[Test]
		public void SetFlag()
		{
			var p1 = _contexts.game.CreateEntity();

			_contexts.game.SetPlayingOrder(new List<GameEntity>() { p1 });

			_contexts.game.SetRoundIndex(0);
			_systems.Execute();

			Assert.IsTrue(p1.isPlaying);
		}

		[Test]
		public void PassFlag()
		{
			var p1 = _contexts.game.CreateEntity();
			p1.isPlaying = true;

			var p2 = _contexts.game.CreateEntity();

			_contexts.game.SetPlayingOrder(new List<GameEntity>() { p1, p2 });

			_contexts.game.SetRoundIndex(1);
			_systems.Execute();

			Assert.IsFalse(p1.isPlaying);
			Assert.IsTrue(p2.isPlaying);
		}
	}
}

