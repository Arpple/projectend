using NUnit.Framework;
using System;
using End.Game;

namespace End.Test.System
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
			var system = new LoadDeckCardSystem(_contexts, _setting);

			var entity = _contexts.game.CreateEntity();
			entity.AddCard(0, Card.Move);
			entity.isDeckCard = true;

			system.Execute();

			Assert.IsTrue(entity.hasResource);
		}

		[Test]
		public void AllCardHaveAbilityComponent()
		{
			var system = new LoadDeckCardSystem(_contexts, _setting);

			foreach(Card card in Enum.GetValues(typeof(Card)))
			{
				var entity = _contexts.game.CreateEntity();
				entity.AddCard(0, card);
				entity.isDeckCard = true;

				system.Execute();

				Assert.IsTrue(entity.hasResource, card.ToString() + " resource does not have ability");
			}
		}
	}

}
