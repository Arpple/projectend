using System.Linq;
using System.Collections.Generic;
using Entitas;

public class PlayerMissionHunterCompletingSystem : UnitReactiveSystem
{
	private GameContext _gameContext;

	public PlayerMissionHunterCompletingSystem(Contexts contexts) : base(contexts)
	{
		_gameContext = contexts.game;
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.Dead);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.isDead;
	}

	protected override void Execute(List<UnitEntity> entities)
	{
		foreach (var e in entities)
		{
			foreach(var hunter in GetHunters(e))
			{
				hunter.isPlayerMissionCompleted = true;
			}
		}
	}

	private GameEntity[] GetHunters(UnitEntity deadEntity)
	{
		return _gameContext.GetEntitiesWithPlayerMission(PlayerMission.Hunter)
			.Where(e => e.playerMissionTarget.TargetEntity == deadEntity.owner.Entity)
			.ToArray();
	}
}