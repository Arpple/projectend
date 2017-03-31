using UnityEngine;
using System.Collections;
using Entitas;
using System;

namespace End.Game
{
	public class OnDeadBoxSystem : LocalEventSystem
	{
		public OnDeadBoxSystem(Contexts contexts) : base(contexts)
		{

		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Hitpoint, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hitpoint.HitPoint == 0 && entity.unit.OwnerEntity.hasPlayerBox;
		}

		protected override void Process(GameEntity entity)
		{
			var cards = _context.GetBoxCards<IOnDeadAbility>(entity.unit.OwnerEntity);

			foreach (var card in cards)
			{
				var ability = (IOnDeadAbility)card.ability.Ability;
				ability.OnDead(entity);
				EventMoveCard.MoveCardToShareDeck(card);

				if (entity.hitpoint.HitPoint > 0) break;
			}
		}
	}

}
