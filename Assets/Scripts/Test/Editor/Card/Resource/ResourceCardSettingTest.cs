using System.Linq;
using System;
using NUnit.Framework;

namespace Test.CardTest.ResourceTest
{
	public class ResourceCardSettingTest
	{
		private ResourceCardSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting.ResourceCardSetting;
		}

		[Test]
		public void CheckSetting_AllDataTypeNotDupplicate()
		{
			var count = _setting.ResourceCardsData.Count;
			Assert.AreEqual(count, _setting.ResourceCardsData
				.Select(d => d.Type)
				.Distinct()
				.Count()
			);
		}

		[Test]
		public void CheckSetting_AllResourceTypeHaveDataExceptResourceNone()
		{
			foreach(Resource res in Enum.GetValues(typeof(Resource)))
			{
				if(res != Resource.None)
					_setting.GetCardData(res);
			}
		}
	}
}
