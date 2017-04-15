using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine.Assertions;

public class MainMissionMonolithSetupSystem : GameReactiveSystem
{
	private UnitContext _unitContext;
	private TileContext _tileContext;

	public MainMissionMonolithSetupSystem(Contexts contexts) : base(contexts)
	{
		_unitContext = contexts.unit;
		_tileContext = contexts.tile;
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

		var sp = _tileContext.GetEntitiesWithSpawnpoint(-1).FirstOrDefault();
		if(sp == null)
		{
			throw new Exception("Boss Spawnpoint is not set");
		}

		monolith.AddMapPosition(sp.mapPosition.Value);
	}
}