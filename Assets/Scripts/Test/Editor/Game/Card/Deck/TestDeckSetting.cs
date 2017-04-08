using NUnit.Framework;
using System;
using System.Linq;
using Game;

namespace Test.Setting
{
	public class TestDeckSetting
	{
		private DeckSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting.DeckSetting;

			Assert.IsNotNull(_setting.CardBlueprints);
			Assert.IsNotNull(_setting.Deck);
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

