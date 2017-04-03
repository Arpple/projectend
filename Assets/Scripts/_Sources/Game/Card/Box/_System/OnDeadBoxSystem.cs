using UnityEngine;
using Entitas;
using System.Linq;

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
			return entity.hitpoint.Value == 0 && entity.unit.OwnerEntity.hasPlayerBox;
		}

		protected override void Process(GameEntity entity)
		{
			UseReviveCard(entity);
			UseOnDeadCard(entity);
		}

		private void UseReviveCard(GameEntity deadEntity)
		{
			var reviveCard = _context.GetPlayerBoxCards<IReviveAbility>(deadEntity.unit.OwnerEntity)
				.OrderBy(c => c.inBox.Index)
				.FirstOrDefault();
			if (reviveCard != null)
			{
				EventUseCardOnUnit.Create(deadEntity, reviveCard, deadEntity);
			}
		}

		private void UseOnDeadCard(GameEntity deadEntity)
		{
			var onDeadCards = _context.GetPlayerBoxCards<IOnDeadAbility>(deadEntity.unit.OwnerEntity);

			foreach (var card in onDeadCards)
			{
				EventUseCardOnUnit.Create(deadEntity, card, deadEntity);
			}
		}
	}
}
