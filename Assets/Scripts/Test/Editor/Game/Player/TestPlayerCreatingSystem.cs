using System.Collections.Generic;
using Entitas;
using Network;
using NUnit.Framework;
using UnityEngine;

namespace Test.GameTest.PlayerTest
{
	public class TestPlayerCreatingSystem : ContextsTest
	{
		[Test]
		public void PlayerEntityCreated()
		{
			var player = new GameObject().AddComponent<Player>();
			var players = new List<Player> { player };

			var system = new PlayerCreatingSystem(_contexts, players);

			system.Initialize();

			Assert.AreEqual(1, _contexts.game.GetEntities(GameMatcher.Player).Length);
		}
	}
}
