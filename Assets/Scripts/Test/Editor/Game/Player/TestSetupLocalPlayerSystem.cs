using UnityEngine;
using NUnit.Framework;
using Game;
using Entitas;

namespace Test.System
{
	public class TestSetupLocalPlayerSystem : ContextsTest
	{
		[Test]
		public void LocalPlayerComponentAddded()
		{
			var localPlayer = new GameObject().AddComponent<Player>();
			var system = new SetupLocalPlayerSystem(_contexts, localPlayer);

			var entity = _contexts.game.CreateEntity();
			entity.AddPlayer(localPlayer);

			system.Initialize();

			var localPlayers = _contexts.game.GetEntities(GameMatcher.LocalPlayer);
			Assert.AreEqual(1, localPlayers.Length);
			Assert.IsTrue(localPlayers[0].isLocalPlayer);
		}
	}
}
