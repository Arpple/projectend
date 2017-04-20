using System;
using NUnit.Framework;

namespace Test.WeatherTest
{
	public class WeatherSettingTest : IndexDataListTest<Weather, WeatherData>
	{
		WeatherSetting _setting;

		protected override IndexDataList<Weather, WeatherData> GetDataList()
		{
			return TestHelper.GetGameSetting().WeatherSetting;
		}

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().WeatherSetting;
		}

		[Test]
		public void CheckSetting_CostCountWeigthNotEmpty()
		{
			Assert.IsNotNull(_setting.CostCountWeigthList);
			Assert.IsNotEmpty(_setting.CostCountWeigthList);
		}
	}
}
