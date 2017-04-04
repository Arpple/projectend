using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

namespace End.Game
{
	[GameEvent]
	public class EventUseCardOnUnit : GameEventComponent
	{
		public GameEntity UserEntity;
		public GameEntity CardEnttiy;
		public GameEntity TargetEnttiy;

		public static void Create(GameEntity userEntity, GameEntity cardEntity, GameEntity targetEntity)
		{
			Assert.IsTrue(userEntity.hasUnit);
			Assert.IsTrue(cardEntity.hasCard);
			Assert.IsTrue(targetEntity.hasUnit);

			GameEvent.CreateEvent<EventUseCardOnUnit>(userEntity.unit.Id, cardEntity.card.Id, targetEntity.unit.Id);
		}

		public void Decode(int userUnitId, int cardId, int targetUnitId)
		{
			UserEntity = Contexts.sharedInstance.game.GetEntities(GameMatcher.Unit)
				.Where(u => u.unit.Id == userUnitId)
				.First();

			CardEnttiy = Contexts.sharedInstance.game.GetEntities(GameMatcher.Card)
				.Where(c => c.card.Id == cardId)
				.First();

			TargetEnttiy = Contexts.sharedInstance.game.GetEntities(GameMatcher.Unit)
				.Where(u => u.unit.Id == targetUnitId)
				.First();
		}
	}

	public class EventUseCardOnUnitSystem : GameEventSystem
	{
		public EventUseCardOnUnitSystem(Contexts contexts) : base(contexts)
		{
		}

		protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
		{
			return context.CreateCollector(GameEventMatcher.EventUseCardOnUnit, GroupEvent.Added);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.hasEventUseCardOnUnit;
		}

		protected override void Process(GameEventEntity entity)
		{
			var cardEvent = entity.eventUseCardOnUnit;
			var ability = (IActiveAbility)cardEvent.CardEnttiy.ability.Ability;
			ability.OnTargetSelected(cardEvent.UserEntity, cardEvent.TargetEnttiy);

			RemovePlayerCard(cardEvent.CardEnttiy);
		}

		private void RemovePlayerCard(GameEntity card)
		{
			card.RemovePlayerCard();
			if (card.hasInBox) card.RemoveInBox();
		}
	}
}
