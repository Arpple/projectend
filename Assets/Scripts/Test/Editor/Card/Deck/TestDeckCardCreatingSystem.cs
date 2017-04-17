using NUnit.Framework;

using Entitas;

namespace Test.CardTest.DeckTest
{
	public class TestDeckCardCreatingSystem : ContextsTest
	{
		[Test]
		public void CreatedEntityCount()
		{
			var deck = new DeckData();
			deck.SettingList.Add(new DeckData.CardDeckCount()
			{
				Type = DeckCard.Move,
				Count = 2
			});

			var system = new DeckCardCreatingSystem(_contexts, deck);
			system.Initialize();

			var cards = _contexts.card.GetEntities(CardMatcher.DeckCard);
			Assert.AreEqual(2, cards.Length);
		}
	}
}

