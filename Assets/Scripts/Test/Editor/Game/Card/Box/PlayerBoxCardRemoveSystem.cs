﻿using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using End.Game;
using End.Game.UI;

namespace End.Test
{
	public class TestPlayerBoxCardRemoveSystem
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

		[Test]
		public void RemovedCardMoveToDeck()
		{
			var system = new PlayerBoxCardRemoveSystem(_contexts);

			var player = new GameObject().AddComponent<Player>();
			player.PlayerId = 1;

			var container = _contexts.game.CreateEntity();
			container.AddPlayer(player);
			var deck = new GameObject().AddComponent<PlayerDeck>();
			deck.Init();
			container.AddPlayerDeck(deck);

			var card = _contexts.game.CreateEntity();
			card.AddPlayerCard(container);
			card.isDeckCard = true;
			card.AddView(new GameObject());
			card.AddInBox(0);

			card.RemoveInBox();

			system.Execute();

			Assert.AreEqual(container.playerDeck.PlayerDeckObject.Content, card.view.GameObject.transform.parent.gameObject);
		}
	}

}

