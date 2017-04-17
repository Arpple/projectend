using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class TurnNotificationSystem : ReactiveSystem<GameEntity>
{
	private GameContext _context;
	private TurnNotification _noti;

	public TurnNotificationSystem(Contexts contexts, TurnNotification notification) : base(contexts.game)
	{
		_context = contexts.game;
		_noti = notification;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Turn);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasTurn;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		var e = entities[entities.Count - 1];
		_noti.Show(e.turn.Count.ToString(), GetPlayerName());
	}

	private string GetPlayerName()
	{
		return _context.playingEntity.player.PlayerObject.GetName();
	}
}