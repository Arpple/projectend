using NUnit.Framework;
using System;
using End.Game;

namespace End.Test
{
	public class TestLoadCardSystem
	{
		private Contexts _contexts;
		private CardSetting _setting;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			_setting = TestHelper.GetGameSetting().DeckSetting.CardSetting;
		}

		[Test]
		public void LoadCard()
		{
			var system = new LoadCardSystem(_contexts, _setting);

			var entity = _contexts.game.CreateEntity();
			entity.AddCard(Card.Move);

			system.Execute();

			Assert.IsTrue(entity.hasResource);
		}

		[Test]
		public void AllCardHaveAbilityComponent()
		{
			var system = new LoadCardSystem(_contexts, _setting);

			foreach(Card card in Enum.GetValues(typeof(Card)))
			{
				var entity = _contexts.game.CreateEntity();
				entity.AddCard(card);

				system.Execute();

				Assert.IsTrue(entity.hasResource, card.ToString() + " resource does not have ability");
			}
		}
	}

}
