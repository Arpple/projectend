﻿using Entitas;
using System.Collections.Generic;

namespace Game.UI
{
	public class LocalPlayerDeckCardStatusSystem : ReactiveSystem<CardEntity>
	{
		private readonly GameContext _gameContext;
		private readonly CardContext _context;
		private readonly PlayerUnitStatusPanel _status;

		public LocalPlayerDeckCardStatusSystem(Contexts contexts, PlayerUnitStatusPanel status) : base(contexts.card)
		{
			_gameContext = contexts.game;
			_context = contexts.card;
			_status = status;
		}

		protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
		{
			return new Collector<CardEntity>(
				new[]
				{
					context.GetGroup(CardMatcher.GameOwner),
					context.GetGroup(CardMatcher.GameInBox),
				},
				new[]
				{
					GroupEvent.AddedOrRemoved,
					GroupEvent.AddedOrRemoved
				}
			);
		}

		protected override bool Filter(CardEntity entity)
		{
			return entity.isGameDeckCard;
		}

		protected override void Execute(List<CardEntity> entities)
		{
			var deckCardCount = _context.GetPlayerDeckCards(_gameContext.gameLocalPlayerEntity)
				.Length;
			var boxCardCount = _context.GetPlayerBoxCards(_gameContext.gameLocalPlayerEntity)
				.Length;

			_status.UpdateDeckCardCount(deckCardCount);
			_status.UpdateBoxCardCount(boxCardCount);
		}
	}

}