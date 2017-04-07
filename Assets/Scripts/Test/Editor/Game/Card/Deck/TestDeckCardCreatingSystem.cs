using NUnit.Framework;
using Game;
using Entitas;

namespace Test.System
{
	public class TestDeckCardCreatingSystem : ContextsTest
	{
		[Test]
		public void CreatedEntityCount()
		{
			var deck = new DeckCardData();
			deck.SettingList.Add(new DeckCardData.CardDeckCount()
			{
				Type = Card.Move,
				Count = 2
			});

			var system = new DeckCardCreatingSystem(_contexts, deck);
			system.Initialize();

			var cards = _contexts.card.GetEntities(CardMatcher.GameCard);
			Assert.AreEqual(2, cards.Length);
		}
	}
}

