using UnityEngine;
using Entitas;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Game
{
	public class OnDeadAbilitySystem : ReactiveSystem<GameEntity>
	{
		private readonly CardContext _cardContext;

		public OnDeadAbilitySystem(Contexts contexts) : base(contexts.game)
		{
			_cardContext = contexts.card;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameHitpoint, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.gameHitpoint.Value == 0 && entity.gameUnit.OwnerEntity.hasGamePlayerBox;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				UseBoxReviveCard(e);
				UseBoxOnDeadCard(e);
			}
		}

		private void UseBoxReviveCard(GameEntity deadEntity)
		{
			var card = _cardContext.GetPlayerBoxCards<IReviveAbility>(deadEntity.gameUnit.OwnerEntity)
				.OrderBy(c => c.gameInBox.Index)
				.FirstOrDefault();
			if (card != null)
			{
				var ability = (IReviveAbility)card.gameAbility.Ability;
				ability.OnDead(deadEntity);
				card.MoveCardToDeck();
			}
		}

		private void UseBoxOnDeadCard(GameEntity deadEntity)
		{
			var cards = _cardContext.GetPlayerBoxCards<IOnDeadAbility>(deadEntity.gameUnit.OwnerEntity);

			foreach (var card in cards)
			{
				var ability = (IOnDeadAbility)card.gameAbility.Ability;
				ability.OnDead(deadEntity);
				card.MoveCardToDeck();
			}
		}
	}
}
