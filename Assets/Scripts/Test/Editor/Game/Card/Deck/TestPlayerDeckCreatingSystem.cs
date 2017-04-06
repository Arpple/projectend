using UnityEngine;
using NUnit.Framework;
using Game;
using Game.UI;
using System.Linq;
using Entitas;

namespace Test.System
{
	public class TestPlayerDeckCreatingSystem : ContextsTest
	{
		private PlayerDeckFactory _decks;

		[SetUp]
		public void Init()
		{
			var obj = new GameObject();
			_decks = obj.AddComponent<PlayerDeckFactory>();
			_decks.ContainerPrefabs = new GameObject().AddComponent<CardContainer>();
			_decks.Init();
		}

		[Test]
		public void CreateDeck()
		{
			var system = new PlayerDeckCreatingSystem(_contexts, _decks);
			var entity = _contexts.game.CreateEntity();

			var player = new GameObject().AddComponent<Player>();
			player.PlayerId = 1;
			entity.AddGamePlayer(player);

			system.Initialize();

			Assert.AreEqual(_decks.AllContainers[1], _contexts.game.GetEntities(GameMatcher.GamePlayerDeck).First().gamePlayerDeck.PlayerDeckObject);
		}
	}
}

