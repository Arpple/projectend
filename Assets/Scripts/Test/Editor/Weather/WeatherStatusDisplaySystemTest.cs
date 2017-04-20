using NUnit.Framework;

namespace Test.WeatherTest
{
	public class WeatherStatusNameDisplaySystemTest : ContextsTest
	{
		private WeatherStatusPanel _panel;
		private WeatherSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().WeatherSetting;
			_panel = TestHelper.CreateWeatherPanel();
			_systems.Add(new WeatherStatusNameDisplaySystem(_contexts, _setting, _panel));
		}

		[Test]
		public void Execute_WeatherStormAdded_DisplayNameOfWeatherStom()
		{
			_contexts.game.SetWeather(Weather.Storm);
			_systems.Execute();
			Assert.AreEqual(_setting.GetData(Weather.Storm).Name, _panel.WeatherNameText.text);
		}
	}
}
