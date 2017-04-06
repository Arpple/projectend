using NUnit.Framework;
using System;
using Game;

namespace Test.System
{
	public class TestLoadDeckCardSystem : ContextsTest
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
			var system = new LoadCardSystem(_contexts, _setting);

			var entity = _contexts.card.CreateEntity();
			entity.AddGameCard(Card.Move);
			entity.isGameDeckCard = true;

			system.Execute();

			Assert.IsTrue(entity.hasGameResource);
		}

		[Test]
		public void AllCardHaveAbilityComponent()
		{
			var system = new LoadCardSystem(_contexts, _setting);

			foreach(Card card in Enum.GetValues(typeof(Card)))
			{
				var entity = _contexts.card.CreateEntity();
				entity.AddGameCard(card);
				entity.isGameDeckCard = true;

				system.Execute();

				Assert.IsTrue(entity.hasGameResource, card.ToString() + " resource does not have ability");
			}
		}
	}

}
