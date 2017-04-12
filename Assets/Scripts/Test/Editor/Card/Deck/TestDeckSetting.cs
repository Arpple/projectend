using NUnit.Framework;
using System;
using System.Linq;


namespace Test.CardTest.DeckTest
{
	public class TestDeckSetting
	{
		private DeckSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting.DeckSetting;

			Assert.IsNotNull(_setting.Deck);
		}
	}
}

