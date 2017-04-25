using System.Collections.Generic;
using Entitas;

public abstract class MissionBossCompletingSystem : UnitReactiveSystem
{
	protected GameContext _gameContext;
	protected GameEventContext _eventContext;

	public MissionBossCompletingSystem(Contexts contexts) : base(contexts)
	{
		_gameContext = contexts.game;
		_eventContext = contexts.gameEvent;
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.Dead);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.isDead
			&& entity.owner.Entity.isBossPlayer
			&& entity.bossUnit.Type == GetMissionBossType();
	}

	protected abstract Boss GetMissionBossType();

	protected override void Execute(List<UnitEntity> entities)
	{
		_gameContext.isMainMissionCompleted = true;
		var end = _eventContext.CreateEntity();
		end.isEventEndGame = true;
	}
}
