using NUnit.Framework;

namespace Test.WeatherTest
{
	public class WeatherSettingTest
	{
		WeatherSetting _setting;

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
