using NUnit.Framework;

namespace Test.WeatherTest
{
	public class RoundStartWeatherCreateSystemTest : ContextsTest
	{
		private WeatherSetting _setting;
		
		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().WeatherSetting;
			_systems.Add(new RoundStartWeatherCreateSystem(_contexts, _setting));
			_systems.Initialize();
		}

		[Test]
		public void Execute_RandomWeatherWithRandomCostCreate()
		{
			_contexts.game.SetRound(1);
			_systems.Execute();

			Assert.IsTrue(_contexts.game.hasWeather);
			Assert.IsTrue(_contexts.game.hasWeatherCost);
		}
	}
}
