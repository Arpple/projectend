using UnityEngine;
using Entitas;
using System.Linq;
using System;
using System.Collections.Generic;

namespace End.Game
{
	public class OnDeadAbilitySystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;

		public OnDeadAbilitySystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Hitpoint, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hitpoint.Value == 0 && entity.unit.OwnerEntity.hasPlayerBox;
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
			var card = _context.GetPlayerBoxCards<IReviveAbility>(deadEntity.unit.OwnerEntity)
				.OrderBy(c => c.inBox.Index)
				.FirstOrDefault();
			if (card != null)
			{
				var ability = (IReviveAbility)card.ability.Ability;
				ability.OnDead(deadEntity);
				card.MoveCardToDeck();
			}
		}

		private void UseBoxOnDeadCard(GameEntity deadEntity)
		{
			var cards = _context.GetPlayerBoxCards<IOnDeadAbility>(deadEntity.unit.OwnerEntity);

			foreach (var card in cards)
			{
				var ability = (IOnDeadAbility)card.ability.Ability;
				ability.OnDead(deadEntity);
				card.MoveCardToDeck();
			}
		}
	}
}
