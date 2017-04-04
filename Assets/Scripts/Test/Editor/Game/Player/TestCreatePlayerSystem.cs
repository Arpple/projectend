using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Game;
using Entitas;

namespace Test.System
{
	public class TestCreatePlayerSystem : ContextsTest
	{
		[Test]
		public void PlayerEntityCreated()
		{
			var player = new GameObject().AddComponent<Player>();
			var players = new List<Player> { player };

			var system = new CreatePlayerSystem(_contexts, players);

			system.Initialize();

			Assert.AreEqual(1, _contexts.game.GetEntities(GameMatcher.Player).Length);
		}
	}
}
