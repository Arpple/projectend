using Entitas;
using Network;
using NUnit.Framework;
using UnityEngine;

namespace Test.GameTest.PlayerTest
{
	public class TestLocalPlayerSetupSystem : ContextsTest
	{
		[Test]
		public void LocalPlayerComponentAddded()
		{
			var localPlayer = new GameObject().AddComponent<Player>();
			var system = new LocalPlayerSetupSystem(_contexts, localPlayer);

			var entity = _contexts.game.CreateEntity();
			entity.AddPlayer(localPlayer);

			system.Initialize();

			var localPlayers = _contexts.game.GetEntities(GameMatcher.Local);
			Assert.AreEqual(1, localPlayers.Length);
			Assert.IsTrue(localPlayers[0].isLocal);
		}
	}
}
