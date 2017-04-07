using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game
{
	[GameEvent]
	public class EventUseCardOnUnit : GameEventComponent
	{
		public UnitEntity UserEntity;
		public CardEntity CardEntity;
		public UnitEntity TargetEntity;

		public static void Create(UnitEntity userEntity, CardEntity cardEntity, UnitEntity targetEntity)
		{
			Assert.IsTrue(cardEntity.hasGameCard);

			GameEvent.CreateEvent<EventUseCardOnUnit>(userEntity.gameId.Id, cardEntity.gameId.Id, targetEntity.gameId.Id);
		}

		public void Decode(int userUnitId, int cardId, int targetUnitId)
		{
			UserEntity = Contexts.sharedInstance.unit.GetEntitiesWithGameId(userUnitId)
				.First();

			CardEntity = Contexts.sharedInstance.card.GetEntitiesWithGameId(cardId)
				.First();

			TargetEntity = Contexts.sharedInstance.unit.GetEntitiesWithGameId(targetUnitId)
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
			return context.CreateCollector(GameEventMatcher.GameEventUseCardOnUnit, GroupEvent.Added);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.hasGameEventUseCardOnUnit;
		}

		protected override void Process(GameEventEntity entity)
		{
			var cardEvent = entity.gameEventUseCardOnUnit;
			var ability = (ActiveAbility<UnitEntity>)cardEvent.CardEntity.gameAbility.Ability;
			ability.OnTargetSelected(cardEvent.UserEntity, cardEvent.TargetEntity);

			if(cardEvent.CardEntity.isGameDeckCard)
				RemovePlayerCard(cardEvent.CardEntity);
		}

		private void RemovePlayerCard(CardEntity card)
		{
			card.RemoveGameOwner();
			if (card.hasGameInBox) card.RemoveGameInBox();
		}
	}
}
