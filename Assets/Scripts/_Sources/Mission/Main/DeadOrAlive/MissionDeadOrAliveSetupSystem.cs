using System.Collections.Generic;
using Entitas;

public class MissionDeadOrAliveSetupSystem : GameReactiveSystem
{
	public MissionDeadOrAliveSetupSystem(Contexts contexts) : base(contexts)
	{
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.MainMission);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasMainMission && entity.mainMission.Type == MainMission.DeadOrAlive;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		_context.isMainMissionCompleted = true;
	}
}