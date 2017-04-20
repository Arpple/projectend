using System.Collections.Generic;
using Entitas;

public class WeatherStatusNameDisplaySystem : GameReactiveSystem
{
	private WeatherSetting _setting;
	private WeatherStatusPanel _panel;

	public WeatherStatusNameDisplaySystem(Contexts contexts, WeatherSetting setting, WeatherStatusPanel panel) : base(contexts)
	{
		_setting = setting;
		_panel = panel;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Weather);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasWeather;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach(var e in entities)
		{
			_panel.SetWeatherName(_setting.GetData(e.weather.Type).Name);
		}
	}
}