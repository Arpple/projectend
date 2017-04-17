using UnityEngine;
using NUnit.Framework;

namespace Test.CardTest.BoxTest
{
	public class TestBoxCardRenderingSystem : ContextsTest
	{
		private GameEntity _player;

		[SetUp]
		public void Init()
		{
			_player = CreatePlayerEntity(1);
			var box = new GameObject().AddComponent<PlayerBox>();
			box.Init();
			_player.AddPlayerBox(box);

			var deck = new GameObject().AddComponent<CardContainer>();
			deck.Init();
			_player.AddPlayerDeck(deck);
		}

		[Test]
		public void InBoxComponentAdd()
		{
			var system = new BoxCardRenderingSystem(_contexts);

			var card = _contexts.card.CreateEntity();
			card.AddOwner(_player);
			card.AddDeckCard(DeckCard.Move);
			card.AddView(new GameObject());
			card.AddInBox(0);

			system.Execute();

			Assert.AreEqual(_player.playerBox.BoxObject.ObjectContainer, card.view.GameObject.transform.parent.gameObject);
		}

		[Test]
		public void InBoxComponentRemove()
		{
			var system = new BoxCardRenderingSystem(_contexts);

			var card = _contexts.card.CreateEntity();
			card.AddOwner(_player);
			card.AddDeckCard(DeckCard.Move);
			card.AddView(new GameObject());
			card.AddInBox(0);
			card.RemoveInBox();

			system.Execute();

			Assert.AreEqual(_player.playerDeck.PlayerDeckObject.ObjectContainer, card.view.GameObject.transform.parent.gameObject);
		}
	}

}

