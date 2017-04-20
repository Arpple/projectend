using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

public class MainMissionCompleteGameEndSystem : GameReactiveSystem
{
	private GameEventContext _eventContext;

	public MainMissionCompleteGameEndSystem(Contexts contexts) : base(contexts)
	{
		_eventContext = contexts.gameEvent;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.MainMissionCompleted);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isMainMissionCompleted;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		var eventEntity = _eventContext.CreateEntity();
		eventEntity.isEventEndGame = true;
	}
}