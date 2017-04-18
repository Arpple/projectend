using NUnit.Framework;
using System;
using System.Linq;


namespace Test.CardTest.DeckTest
{
	public class DeckSettingTest : IndexDataListTest<DeckCard, DeckCardData>
	{
		private DeckSetting _setting;

		protected override IndexDataList<DeckCard, DeckCardData> GetDataList()
		{
			return TestHelper.GetGameSetting().CardSetting.DeckSetting;
		}

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting.DeckSetting;
		}

		[Test]
		public void CheckSetting_DeckAdded()
		{
			Assert.IsNotNull(_setting.Deck);
		}

		[Test]
		public void CheckSetting_CardInDeckIsNotDupplicate()
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
				Assert.IsNotNull(_setting.GetData(set.Type));
			}
		}
	}
}

