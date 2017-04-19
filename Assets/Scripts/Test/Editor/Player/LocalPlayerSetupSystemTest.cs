using Entitas;
using Network;
using NUnit.Framework;
using UnityEngine;

namespace Test.PlayerTest
{
	public class LocalPlayerSetupSystemTest : ContextsTest
	{

		[Test]
		public void Initialize_LocalPlayerEntityCreated_LocalFlagAdded()
		{
			var localPlayer = new GameObject().AddComponent<Player>();
			var system = new LocalPlayerSetupSystem(_contexts, localPlayer);

			var entity = _contexts.game.CreateEntity();
			entity.AddPlayer(localPlayer);

			system.Initialize();

			Assert.AreEqual(localPlayer, _contexts.game.localEntity.player.PlayerObject);
		}
	}
}
