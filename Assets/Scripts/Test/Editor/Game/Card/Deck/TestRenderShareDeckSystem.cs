using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Game;
using Game.UI;

namespace Test.System
{
	public class TestRenderShareDeckSystem : ContextsTest
	{
		private CardContainer _deck;

		[SetUp]
		public void Init()
		{
			var obj = new GameObject();
			_deck = obj.AddComponent<CardContainer>();
			_deck.Init();
		}

		[Test]
		public void CardMoveToDeckWhenPlayerCardComponentRemoved()
		{
			var system = new RenderShareDeckSystem(_contexts, _deck);
			var card = _contexts.game.CreateEntity();
			card.AddPlayerCard(null);
			card.isDeckCard = true;
			card.RemovePlayerCard();
			card.AddView(new GameObject());

			system.Execute();

			Assert.AreEqual(_deck.ObjectContainer, card.view.GameObject.transform.parent.gameObject);
		}
	}

}

