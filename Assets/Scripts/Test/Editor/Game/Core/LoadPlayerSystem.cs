using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using End.Game;
using Entitas;

namespace End.Test
{
	public class TestLoadPlayerSystem
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

		[Test]
		public void PlayerEntityCreated()
		{
			var player = new GameObject().AddComponent<Player>();
			var players = new List<Player> { player };

			var system = new LoadPlayerSystem(_contexts, players);

			system.Initialize();

			Assert.AreEqual(1, _contexts.game.GetEntities(GameMatcher.Player).Length);
		}
	}
}
