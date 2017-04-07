using UnityEngine;
using Entitas;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Game
{
	public class OnDeadAbilitySystem : ReactiveSystem<UnitEntity>
	{
		private readonly CardContext _cardContext;

		public OnDeadAbilitySystem(Contexts contexts) : base(contexts.unit)
		{
			_cardContext = contexts.card;
		}

		protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
		{
			return context.CreateCollector(UnitMatcher.GameHitpoint, GroupEvent.Added);
		}

		protected override bool Filter(UnitEntity entity)
		{
			return entity.gameHitpoint.Value == 0 && entity.gameOwner.Entity.hasGamePlayerBox;
		}

		protected override void Execute(List<UnitEntity> entities)
		{
			foreach(var e in entities)
			{
				UseBoxReviveCard(e);
				UseBoxOnDeadCard(e);
			}
		}

		private void UseBoxReviveCard(UnitEntity deadEntity)
		{
			var card = _cardContext.GetPlayerBoxCards<IReviveAbility>(deadEntity.gameOwner.Entity)
				.OrderBy(c => c.gameInBox.Index)
				.FirstOrDefault();
			if (card != null)
			{
				var ability = (IReviveAbility)card.gameAbility.Ability;
				ability.OnDead(deadEntity);
				card.MoveCardToDeck();
			}
		}

		private void UseBoxOnDeadCard(UnitEntity deadEntity)
		{
			var cards = _cardContext.GetPlayerBoxCards<IOnDeadAbility>(deadEntity.gameOwner.Entity);

			foreach (var card in cards)
			{
				var ability = (IOnDeadAbility)card.gameAbility.Ability;
				ability.OnDead(deadEntity);
				card.MoveCardToDeck();
			}
		}
	}
}
