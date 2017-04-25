using System.Collections.Generic;
using System.Linq;
using Entitas;

public class AllPlayerDeadGameEnd : UnitReactiveSystem
{
	private GameEventContext _eventContext;
	private GameContext _gameContext;

	public AllPlayerDeadGameEnd(Contexts contexts) : base(contexts)
	{
		_eventContext = contexts.gameEvent;
		_gameContext = contexts.game;
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.Dead);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.isDead
			&& !entity.owner.Entity.isBossPlayer;
	}

	protected override void Execute(List<UnitEntity> entities)
	{
		if (_context.GetEntities(UnitMatcher.Owner)
			.Where(e => !e.owner.Entity.isBossPlayer)
			.ToList()
			.TrueForAll(e => e.isDead)
		)
		{
			var end = _eventContext.CreateEntity();
			end.isEventEndGame = true;
		}
	}
}

	