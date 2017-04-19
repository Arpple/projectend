﻿using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BossActiveSkillUsingSystem : GameReactiveSystem
{
	private CardContext _cardContext;
	private UnitContext _unitContext;
	private GameEventContext _eventContext;
	private TurnNotification _noti;
	private SystemController _syscon;

	public BossActiveSkillUsingSystem(Contexts contexts, TurnNotification noti, SystemController syscon) : base(contexts)
	{
		_cardContext = contexts.card;
		_unitContext = contexts.unit;
		_eventContext = contexts.gameEvent;
		_noti = noti;
		_syscon = syscon;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Playing);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isPlaying && entity.isBossPlayer;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			var cards = _cardContext.GetPlayerSkills<SelfActiveAbility>(e);
			var unit = _unitContext.GetEntityOwnedBy(e);
			foreach (var card in cards)
			{
				var ability = card.ability.Ability as SelfActiveAbility;
				ability.OnTargetSelected(unit, unit);
			}
		}

		if(_syscon.AutoEndTurnForBoss)
		{
			_noti.AnimationEndAction = () =>
			{
				var endTurnEvent = _eventContext.CreateEntity();
				endTurnEvent.isEventEndTurn = true;
			};
		}
	}
}