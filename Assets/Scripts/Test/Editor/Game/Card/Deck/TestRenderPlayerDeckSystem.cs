using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Game;
using Game.UI;

namespace Test.System
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
			container.AddGamePlayer(player);
			var deck = new GameObject().AddComponent<CardContainer>();
			deck.Init();
			container.AddGamePlayerDeck(deck);
			
			var card = _contexts.card.CreateEntity();
			card.AddGameOwner(container);
			card.isGameDeckCard = true;
			card.AddGameView(new GameObject());

			system.Execute();

			Assert.AreEqual(container.gamePlayerDeck.PlayerDeckObject.ObjectContainer, card.gameView.GameObject.transform.parent.gameObject);
		}
	}

}

