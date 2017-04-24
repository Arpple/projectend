using System.Collections.Generic;
using Entitas;
using Network;
using NUnit.Framework;
using UnityEngine;
using Entitas.Unity;

namespace Test.PlayerTest
{
	public class PlayerCreatingSystemTest : ContextsTest
	{
		[Test]
		public void Initialize_PlayerListAssigned_EntityCreated()
		{
			var player = new GameObject().AddComponent<Player>();
			var players = new List<Player> { player };

			var system = new PlayerCreatingSystem(_contexts, players);

			system.Initialize();

			var playerEntities = _contexts.game.GetEntities(GameMatcher.Player);
			var playerEntity = playerEntities[0];
			Assert.AreEqual(1, playerEntities.Length);
			Assert.AreEqual(player, playerEntity.player.PlayerObject);
			Assert.AreEqual(player.PlayerId, playerEntity.player.PlayerId);
		}
	}
}
