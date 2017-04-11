using System;
using NUnit.Framework;


namespace Test.CardTest.DeckTest
{
	public class TestCardBlueprintLoadingSystem : ContextsTest
	{
		private DeckSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting.DeckSetting;
		}

		[Test]
		public void LoadCard()
		{
			var system = new CardBlueprintLoadingSystem(_contexts, _setting);

			var entity = _contexts.card.CreateEntity();
			entity.AddCard(Card.Move);
			entity.isDeckCard = true;

			system.Execute();

			Assert.IsTrue(entity.hasResource);
		}

		[Test]
		public void AllCardHaveAbilityComponent()
		{
			var system = new CardBlueprintLoadingSystem(_contexts, _setting);

			foreach(Card card in Enum.GetValues(typeof(Card)))
			{
				var entity = _contexts.card.CreateEntity();
				entity.AddCard(card);
				entity.isDeckCard = true;

				system.Execute();

				Assert.IsTrue(entity.hasResource, card.ToString() + " resource does not have ability");
			}
		}
	}

}
