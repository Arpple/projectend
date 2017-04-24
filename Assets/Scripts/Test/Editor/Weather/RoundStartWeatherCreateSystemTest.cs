using Entitas;
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
		public void Execute_LocalEntityIsPlaying_EventCreateWeatherCreated()
		{
			var p = CreatePlayerEntity(1);
			p.isLocal = true;
			p.isPlaying = true;

			_contexts.game.SetRound(1);
			_systems.Execute();

			Assert.AreEqual(1, _contexts.gameEvent.GetEntities(GameEventMatcher.EventCreateWeather).Length);
		}

		[Test]
		public void Execute_LocalEntityIsNotPlaying_EventCreateWeatherNotCreated()
		{
			var p = CreatePlayerEntity(1);
			p.isLocal = true;

			_contexts.game.SetRound(1);
			_systems.Execute();

			Assert.AreEqual(0, _contexts.gameEvent.GetEntities(GameEventMatcher.EventCreateWeather).Length);
		}
	}
}
