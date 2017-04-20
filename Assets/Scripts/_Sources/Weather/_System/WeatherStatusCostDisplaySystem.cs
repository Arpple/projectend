using System.Collections.Generic;
using Entitas;

public class WeatherStatusCostDisplaySystem : GameReactiveSystem
{
	private WeatherStatusPanel _panel;

	public WeatherStatusCostDisplaySystem(Contexts contexts, WeatherStatusPanel panel) : base(contexts)
	{
		_panel = panel;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.WeatherCost);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasWeatherCost;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			var costMap = e.weatherCost.ResourcesCost;
			foreach (var type in costMap.Keys)
			{
				_panel.SetCost(type, costMap[type]);
			}
		}
	}
}