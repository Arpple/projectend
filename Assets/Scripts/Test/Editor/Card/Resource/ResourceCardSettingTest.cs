using System.Linq;
using System;
using NUnit.Framework;

namespace Test.CardTest.ResourceTest
{
	public class ResourceCardSettingTest : IndexDataListTest<Resource, ResourceCardData>
	{
		private ResourceCardSetting _setting;

		protected override IndexDataList<Resource, ResourceCardData> GetDataList()
		{
			return TestHelper.GetGameSetting().CardSetting.ResourceCardSetting;
		}

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting.ResourceCardSetting;
		}

		[Test]
		public void CheckSetting_ResourceIsNotNone_ResourceTypeHaveData()
		{
			foreach(Resource res in Enum.GetValues(typeof(Resource)))
			{
				if(res != Resource.None)
					_setting.GetData(res);
			}
		}

		
	}
}
