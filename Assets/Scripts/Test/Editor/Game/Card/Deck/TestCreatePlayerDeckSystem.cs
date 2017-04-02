using UnityEngine;
using NUnit.Framework;
using End.Game;
using End.Game.UI;
using System.Linq;
using Entitas;

namespace End.Test.System
{
	public class TestCreatePlayerDeckSystem : ContextsTest
	{
		private CardContainer _container;

		[SetUp]
		public void Init()
		{
			var obj = new GameObject();
			_container = obj.AddComponent<CardContainer>();
			_container.PlayerDeckPrefabs = new GameObject().AddComponent<PlayerDeck>();
			_container.Init();
		}

		[Test]
		public void CreateDeck()
		{
			var system = new CreatePlayerDeckSystem(_contexts, _container);
			var entity = _contexts.game.CreateEntity();

			var player = new GameObject().AddComponent<Player>();
			player.PlayerId = 1;
			entity.AddPlayer(player);

			system.Initialize();

			Assert.AreEqual(_container.PlayerDecks[1], _contexts.game.GetEntities(GameMatcher.PlayerDeck).First().playerDeck.PlayerDeckObject);
		}
	}
}

