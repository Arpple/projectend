﻿using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;

public class StartTurnDrawSystem : ReactiveSystem<GameEntity>
{
	private CardContext _cardContext;
	private DeckSetting _setting;
	private GameEventContext _eventContext;

	public StartTurnDrawSystem(Contexts contexts, DeckSetting setting) : base(contexts.game)
	{
		_cardContext = contexts.card;
		_setting = setting;
		_eventContext = contexts.gameEvent;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Playing);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isPlaying && entity.isLocal && !entity.isBossPlayer;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			var movingCards = _eventContext.GetEntities(GameEventMatcher.EventMoveDeckCard)
				.Select(ev => ev.eventMoveDeckCard.CardEntity);
			var cards = _cardContext.GetEntities(CardMatcher.DeckCard)
			.Except(movingCards)
			.ToArray()
			.Shuffle();

			if (cards.Length > 0)
			{
				var drawCards = cards.Take(Math.Min(cards.Length, _setting.StartTurnDrawCount));
				foreach (var c in drawCards)
				{
					EventMoveDeckCard.MoveCardToPlayer(c, e);
				}
			}
		}
	}
}