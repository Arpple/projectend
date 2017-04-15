using System.Collections.Generic;
using Entitas;
using UnityEngine.Assertions;

public class MainMissionMonolithSetupSystem : GameReactiveSystem
{
	private UnitContext _unitContext;

	public MainMissionMonolithSetupSystem(Contexts contexts) : base(contexts)
	{
		_unitContext = contexts.unit;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.MainMission);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.mainMission.Type == MainMission.BossMonolith;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		Assert.AreEqual(1, entities.Count);

		var e = _context.CreateEntity();
		e.isBossPlayer = true;

		var monolith = _unitContext.CreateEntity();
		monolith.AddBossUnit(Boss.Monolith);
		monolith.AddOwner(e);
	}
}