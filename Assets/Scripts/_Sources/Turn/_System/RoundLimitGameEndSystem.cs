using System.Collections.Generic;
using Entitas;

public class RoundLimitGameEndSystem : GameReactiveSystem
{
	private GameEventContext _eventContext;

	public RoundLimitGameEndSystem(Contexts contexts) : base(contexts)
	{
		_eventContext = contexts.gameEvent;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Round);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasRound;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach(var e in entities)
		{
			if(e.round.Count == _context.roundLimit.Count)
			{
				var eventEntity = _eventContext.CreateEntity();
				eventEntity.isEventEndGame = true;
			}
		}
	}
}
