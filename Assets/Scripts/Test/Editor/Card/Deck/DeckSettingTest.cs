using NUnit.Framework;
using System;
using System.Linq;


namespace Test.CardTest.DeckTest
{
	public class DeckSettingTest
	{
		private CardSetting _cardSetting;
		private DeckSetting _setting;

		[SetUp]
		public void Init()
		{
			_cardSetting = TestHelper.GetGameSetting().CardSetting;
			_setting = _cardSetting.DeckSetting;
		}

		[Test]
		public void CheckSetting_DeckSettingAdded()
		{
			Assert.IsNotNull(_setting.Deck);
		}

		[Test]
		public void CheckSetting_DeckSettingIsNotDupplicate()
		{
			var setCount = _setting.Deck.SettingList.Count;
			Assert.AreEqual(setCount, _setting.Deck.SettingList
				.Select(set => set.Type)
				.Distinct()
				.Count()
			);
		}

		[Test]
		public void CheckSetting_AllDeckCardHaveData()
		{
			foreach(var set in _setting.Deck.SettingList)
			{
				Assert.IsNotNull(_cardSetting.GetCardData(set.Type));
			}
		}
	}
}

