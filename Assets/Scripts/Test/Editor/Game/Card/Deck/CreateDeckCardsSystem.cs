using NUnit.Framework;
using End.Game;

namespace End.Test
{
	public class TestCreateDeckCardsSystem
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

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

