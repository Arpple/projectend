using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using End.Game;
using End.Game.UI;

namespace End.Test
{
	public class TestRenderShareDeckSystem
	{
		private Contexts _contexts;
		private PlayerDeck _deck;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			var obj = new GameObject();
			_deck = obj.AddComponent<PlayerDeck>();
			_deck.Init();
		}

		[Test]
		public void CardMoveToDeckWhenPlayerCardComponentRemoved()
		{
			var system = new RenderShareDeckSystem(_contexts, _deck);
			var card = _contexts.game.CreateEntity();
			card.AddPlayerCard(1);
			card.isDeckCard = true;
			card.RemovePlayerCard();
			card.AddView(new GameObject());

			system.Execute();

			Assert.AreEqual(_deck.Content, card.view.GameObject.transform.parent.gameObject);
		}
	}

}

