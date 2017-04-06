using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game
{
	[GameEvent]
	public class EventUseCardOnUnit : GameEventComponent
	{
		public GameEntity UserEntity;
		public CardEntity CardEntity;
		public GameEntity TargetEntity;

		public static void Create(GameEntity userEntity, CardEntity cardEntity, GameEntity targetEntity)
		{
			Assert.IsTrue(userEntity.hasGameUnit);
			Assert.IsTrue(cardEntity.hasGameCard);
			Assert.IsTrue(targetEntity.hasGameUnit);

			GameEvent.CreateEvent<EventUseCardOnUnit>(userEntity.gameUnit.Id, cardEntity.gameId.Id, targetEntity.gameUnit.Id);
		}

		public void Decode(int userUnitId, int cardId, int targetUnitId)
		{
			UserEntity = Contexts.sharedInstance.game.GetEntities(GameMatcher.GameUnit)
				.Where(u => u.gameUnit.Id == userUnitId)
				.First();

			CardEntity = Contexts.sharedInstance.card.GetEntities(CardMatcher.GameCard)
				.Where(c => c.gameId.Id == cardId)
				.First();

			TargetEntity = Contexts.sharedInstance.game.GetEntities(GameMatcher.GameUnit)
				.Where(u => u.gameUnit.Id == targetUnitId)
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
			var ability = (ActiveAbility<GameEntity>)cardEvent.CardEntity.gameAbility.Ability;
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
