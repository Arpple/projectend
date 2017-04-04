using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestCreateDeckCardsSystem : ContextsTest
	{
		[Test]
		public void CreatedEntityCount()
		{
			var deck = new CardDeck();
			deck.SettingList.Add(new CardDeck.CardDeckCount()
			{
				Type = Card.Move,
				Count = 2
			});

			var system = new CreateDeckCardsSystem(_contexts, deck);
			system.Initialize();

			var cards = _contexts.game.GetGroup(GameMatcher.Card).GetEntities();
			Assert.AreEqual(2, cards.Length);
		}
	}
}

