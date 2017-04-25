using System.Collections.Generic;
using Entitas;

public class MissionDeadOrAliveFailSystem : GameReactiveSystem
{
	private GameEventContext _eventContext;
	private WeatherResloveDisplayer _display;

	public MissionDeadOrAliveFailSystem(Contexts contexts, WeatherResloveDisplayer weatherDisplay) : base(contexts)
	{
		_eventContext = contexts.gameEvent;
		_display = weatherDisplay;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.WeatherResloveFail);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isWeatherResloveFail && _context.mainMission.Type == MainMission.DeadOrAlive;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		_context.isMainMissionCompleted = false;
		_display.AddOnResolveAction(EndGame);
	}

	private void EndGame()
	{
		var eventEntity = _eventContext.CreateEntity();
		eventEntity.isEventEndGame = true;
	}
}