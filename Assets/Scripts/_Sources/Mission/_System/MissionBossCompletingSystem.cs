using System.Collections.Generic;
using Entitas;

public abstract class MissionBossCompletingSystem : UnitReactiveSystem
{
	protected GameContext _gameContext;

	public MissionBossCompletingSystem(Contexts contexts) : base(contexts)
	{
		_gameContext = contexts.game;
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
	}
}
