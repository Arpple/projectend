using UnityEngine;
using NUnit.Framework;
using End.Game;
using End.Game.UI;
using System.Linq;
using Entitas;

namespace End.Test
{
	public class TestCreatePlayerDeckSystem
	{
		private Contexts _contexts;
		private CardContainer _container;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			var obj = new GameObject();
			_container = obj.AddComponent<CardContainer>();
			_container.Awake();
		}

		[Test]
		public void CreateMiddleDeck()
		{
			var system = new CreatePlayerDeckSystem(_contexts, _container);
			system.Initialize();

			Assert.IsNotNull(_container.PlayerDecks[0]);
		}

		[Test]
		public void CreateDeckWhenPlayerCreated()
		{
			var system = new CreatePlayerDeckSystem(_contexts, _container);
			var entity = _contexts.game.CreateEntity();

			var player = new GameObject().AddComponent<Player>();
			player.PlayerId = 1;
			entity.AddPlayer(player);

			system.Execute();

			Assert.AreEqual(_container.PlayerDecks[1], _contexts.game.GetEntities(GameMatcher.PlayerDeck).First().playerDeck.PlayerDeckObject);
		}
	}
}

