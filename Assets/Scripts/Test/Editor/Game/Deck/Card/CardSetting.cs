using NUnit.Framework;
using System;
using End.Game;

namespace End.Test
{
	public class TestCardSetting
	{
		private CardSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().DeckSetting.CardSetting;
		}

		[Test]
		public void CheckEnumBlueprint()
		{
			foreach (Card c in Enum.GetValues(typeof(Card)))
			{
				Assert.IsNotNull(_setting.GetCardBlueprint(c), "Card blueprint not fonud for " + c.ToString());
			}
		}
	}
}

