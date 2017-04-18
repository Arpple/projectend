using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public abstract class MissionBossSetupSystem : GameReactiveSystem
{
	private UnitContext _unitContext;
	private TileContext _tileContext;

	public MissionBossSetupSystem(Contexts contexts) : base(contexts)
	{
		_unitContext = contexts.unit;
		_tileContext = contexts.tile;
	}

	protected abstract MainMission GetMainMissionType();
	protected abstract Boss GetBossType();

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.MainMission);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.mainMission.Type == GetMainMissionType();
	}

	protected override void Execute(List<GameEntity> entities)
	{
		var player = CreateBossPlayer();
		var boss = CreateBossUnit();
		boss.AddOwner(player);
		boss.AddMapPosition(GetBossPosition());
		AddBossPlayerToPlayingOrder(player);
	}

	private GameEntity CreateBossPlayer()
	{
		var e = _context.CreateEntity();
		e.isBossPlayer = true;
		e.AddPlayer(new BossPlayer());
		return e;
	}

	private UnitEntity CreateBossUnit()
	{
		var boss = _unitContext.CreateEntity();
		boss.AddBossUnit(GetBossType());
		return boss;
	}

	private Position GetBossPosition()
	{
		var sp = _tileContext.GetEntitiesWithSpawnpoint(-1).FirstOrDefault();
		if(sp == null)
		{
			throw new Exception("Boss spawnpoint is not set in map");
		}

		return sp.mapPosition.Value;
	}

	private void AddBossPlayerToPlayingOrder(GameEntity player)
	{
		var order = _context.playingOrder.PlayerOrder;
		order.Add(player);

		_context.ReplacePlayingOrder(order);
	}
}