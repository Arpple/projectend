﻿using Entitas;
using System.Collections.Generic;

namespace Game.UI
{
	public class TargetDeckCardStatusRendingSystem : ReactiveSystem<CardEntity>
	{
		private readonly CardContext _context;
		private readonly PlayerUnitStatusPanel _status;

		public TargetDeckCardStatusRendingSystem(Contexts contexts, PlayerUnitStatusPanel status) : base(contexts.card)
		{
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
			return _status.ShowingCharacter != null;
		}

		protected override void Execute(List<CardEntity> entities)
		{
			var deckCardCount = _context.GetPlayerDeckCards(_status.ShowingCharacter.gameOwner.Entity)
				.Length;
			var boxCardCount = _context.GetPlayerBoxCards(_status.ShowingCharacter.gameOwner.Entity)
				.Length;

			_status.UpdateDeckCardCount(deckCardCount);
			_status.UpdateBoxCardCount(boxCardCount);
		}
	}

}