using UnityEngine;
using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestTurnAndRoundSetupSystem : ContextsTest
	{
		[Test]
		public void StartRound()
		{
			_systems.Add(new TurnAndRoundSetupSystem(_contexts));
			_systems.Initialize();

			Assert.AreEqual(1, _contexts.game.gameRound.Count);
			Assert.AreEqual(0, _contexts.game.gameRoundIndex.Index);
			Assert.AreEqual(1, _contexts.game.gameTurn.Count);
		}
	}
}
