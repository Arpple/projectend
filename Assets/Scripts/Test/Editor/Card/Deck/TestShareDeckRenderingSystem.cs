using NUnit.Framework;
using UnityEngine;



namespace Test.CardTest.DeckTest
{
	public class TestShareDeckRenderingSystem : ContextsTest
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
			var system = new ShareDeckRenderingSystem(_contexts, _deck);
			var card = _contexts.card.CreateEntity();
			card.AddOwner(null);
			card.isDeckCard = true;
			card.RemoveOwner();
			card.AddView(new GameObject());

			system.Execute();

			Assert.AreEqual(_deck.ObjectContainer, card.view.GameObject.transform.parent.gameObject);
		}
	}

}

