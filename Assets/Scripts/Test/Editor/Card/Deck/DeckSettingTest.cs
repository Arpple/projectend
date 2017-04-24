using NUnit.Framework;

namespace Test.CardTest.DeckTest
{
	public class DeckSettingTest : IndexDataListTest<DeckCard, DeckCardData>
	{
		protected override IndexDataList<DeckCard, DeckCardData> GetDataList()
		{
			return TestHelper.GetGameSetting().CardSetting.DeckSetting;
		}

		DeckSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting.DeckSetting;
		}

		[Test]
		public void CheckSetting_CardCreateCountIsMoreThanOrEqualZero()
		{
			foreach(var data in _setting.DataList)
			{
				Assert.IsTrue(data.CreateCount >= 0);
			}
		}
	
	}
}

