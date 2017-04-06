using UnityEngine;
using NUnit.Framework;
using Game;
using Game.UI;

namespace Test.System
{
	public class TestBoxCardRenderingSystem : ContextsTest
	{
		private GameEntity _player;

		[SetUp]
		public void Init()
		{
			_player = TestHelper.CreatePlayerEntity(_contexts.game, 1);
			var box = new GameObject().AddComponent<PlayerBox>();
			box.Init();
			_player.AddGamePlayerBox(box);

			var deck = new GameObject().AddComponent<CardContainer>();
			deck.Init();
			_player.AddGamePlayerDeck(deck);
		}

		[Test]
		public void InBoxComponentAdd()
		{
			var system = new BoxCardRenderingSystem(_contexts);

			var card = _contexts.card.CreateEntity();
			card.AddGameOwner(_player);
			card.isGameDeckCard = true;
			card.AddGameView(new GameObject());
			card.AddGameInBox(0);

			system.Execute();

			Assert.AreEqual(_player.gamePlayerBox.BoxObject.ObjectContainer, card.gameView.GameObject.transform.parent.gameObject);
		}

		[Test]
		public void InBoxComponentRemove()
		{
			var system = new BoxCardRenderingSystem(_contexts);

			var card = _contexts.card.CreateEntity();
			card.AddGameOwner(_player);
			card.isGameDeckCard = true;
			card.AddGameView(new GameObject());
			card.AddGameInBox(0);
			card.RemoveGameInBox();

			system.Execute();

			Assert.AreEqual(_player.gamePlayerDeck.PlayerDeckObject.ObjectContainer, card.gameView.GameObject.transform.parent.gameObject);
		}
	}

}

