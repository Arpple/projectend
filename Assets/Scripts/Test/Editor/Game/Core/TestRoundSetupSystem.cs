using UnityEngine;
using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestRoundSetupSystem : ContextsTest
	{
		[Test]
		public void StartRound()
		{
			_systems.Add(new RoundSetupSystem(_contexts));
			_systems.Initialize();

			Assert.AreEqual(0, _contexts.game.gameRound.Index);
			Assert.AreEqual(1, _contexts.game.gameRound.Count);
		}
	}
}
