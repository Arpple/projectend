using Network;
using NUnit.Framework;
using UnityEngine;

namespace Test.CardTest.DeckTest
{
	public class TestRenderPlayerDeckSystem : ContextsTest
	{
		[Test]
		public void CardViewObjectMovedToDeckObject()
		{
			var system = new PlayerDeckRenderingSystem(_contexts);

			var player = new GameObject().AddComponent<Player>();
			player.PlayerId = 1;

			var container = _contexts.game.CreateEntity();
			container.AddPlayer(player);
			var deck = new GameObject().AddComponent<CardContainer>();
			deck.Init();
			container.AddPlayerDeck(deck);
			
			var card = _contexts.card.CreateEntity();
			card.AddOwner(container);
			card.isDeckCard = true;
			card.AddView(new GameObject());

			system.Execute();

			Assert.AreEqual(container.playerDeck.PlayerDeckObject.ObjectContainer, card.view.GameObject.transform.parent.gameObject);
		}
	}

}

