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
			return entity.hitpoint.HitPoint == 0 && entity.unit.OwnerEntity.hasPlayerBox;
		}

		protected override void Process(GameEntity entity)
		{
			var reviveCard = _context.GetBoxCards<IReviveAbility>(entity.unit.OwnerEntity).FirstOrDefault();
			if(reviveCard != null)
			{
				EventUseCardOnUnit.Create(entity, reviveCard, entity);
			}

			var onDeadCards = _context.GetBoxCards<IOnDeadAbility>(entity.unit.OwnerEntity);

			foreach (var card in onDeadCards)
			{
				EventUseCardOnUnit.Create(entity, card, entity);
			}
		}
	}
}
