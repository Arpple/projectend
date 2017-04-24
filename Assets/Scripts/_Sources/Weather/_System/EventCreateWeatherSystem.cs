using Entitas;

public class EventCreateWeatherSystem : EventSystem
{
	public EventCreateWeatherSystem(Contexts contexts) : base(contexts)
	{
	}

	protected override bool Filter(GameEventEntity entity)
	{
		return entity.hasEventCreateWeather;
	}

	protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
	{
		return context.CreateCollector(GameEventMatcher.EventCreateWeather);
	}

	protected override void Process(GameEventEntity entity)
	{
		var weatherEvent = entity.eventCreateWeather;
		_contexts.game.ReplaceWeather(weatherEvent.Type);
		_contexts.game.ReplaceWeatherCost(weatherEvent.CostMap);
	}
}