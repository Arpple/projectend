using System.Collections.Generic;
using Entitas;

public class MissionDeadOrAliveFailSystem : GameReactiveSystem
{
	private GameEventContext _eventContext;

	public MissionDeadOrAliveFailSystem(Contexts contexts) : base(contexts)
	{
		_eventContext = contexts.gameEvent;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.WeatherResloveFail);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isWeatherResloveFail;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		_context.isMainMissionCompleted = false;
		var eventEntity = _eventContext.CreateEntity();
		eventEntity.isEventEndGame = true;
	}
}