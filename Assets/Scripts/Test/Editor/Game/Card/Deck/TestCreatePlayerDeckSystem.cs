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
			var system = new CreatePlayerDeckSystem(_contexts, _decks);
			var entity = _contexts.game.CreateEntity();

			var player = new GameObject().AddComponent<Player>();
			player.PlayerId = 1;
			entity.AddPlayer(player);

			system.Initialize();

			Assert.AreEqual(_decks.AllContainers[1], _contexts.game.GetEntities(GameMatcher.PlayerDeck).First().playerDeck.PlayerDeckObject);
		}
	}
}

