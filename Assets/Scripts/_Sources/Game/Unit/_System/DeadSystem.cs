using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine.Assertions;

namespace End.Game
{
	public class DeadSystem : ReactiveSystem<GameEntity>
	{
		//private readonly GameContext _context;

		public DeadSystem(Contexts contexts) : base(contexts.game)
		{
			//_context = contexts.game;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Hitpoint, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			Assert.IsFalse(entity.hitpoint.HitPoint < 0);

			return entity.hitpoint.HitPoint == 0;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				//try to call card in box
				if (e.unit.OwnerEntity.hasPlayerBox)
				{
					var box = e.unit.OwnerEntity.playerBox;

					var cards = box.GetBoxCards<IOnDeadAbility>(e.unit.OwnerEntity);

					foreach(var card in cards)
					{
						if (e.hitpoint.HitPoint > 0) break;

						var ability = (IOnDeadAbility)card.ability.Ability;
						ability.OnDead(e);
						EventMoveCard.MoveCardToShareDeck(card);
					}
				}

				if(e.hitpoint.HitPoint == 0)
				{
					e.isDead = true;
				}
			}
		}
	}
}
