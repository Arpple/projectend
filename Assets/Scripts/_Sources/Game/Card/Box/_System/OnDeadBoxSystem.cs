using UnityEngine;
using Entitas;
using System.Linq;
using System;
using System.Collections.Generic;

namespace End.Game
{
	public class OnDeadBoxSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;

		public OnDeadBoxSystem(Contexts contexts) : base(contexts.game)
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
				UseReviveCard(e);
				UseOnDeadCard(e);
			}
		}

		private void UseReviveCard(GameEntity deadEntity)
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

		private void UseOnDeadCard(GameEntity deadEntity)
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
