using Entitas;
using System.Linq;
using UnityEngine.Assertions;
using System;

namespace Game
{
	[GameEvent]
	public class EventMoveCard : GameEventComponent
	{
		public CardEntity CardEntity;
		public GameEntity TargetPlayerEntity;
		public bool IsInBox;

		private static void MoveCard(CardEntity cardEntity, GameEntity playerEntity, bool isMoveTobox)
		{
			Assert.IsTrue(cardEntity.hasGameCard);

			GameEvent.CreateEvent<EventMoveCard>(
				cardEntity.gameId.Id,
				playerEntity != null 
					? playerEntity.gamePlayer.PlayerId 
					: 0, 
				isMoveTobox 
					? 1 
					: 0
			);
		}

		public static void MoveCardToPlayer(CardEntity cardEntity, GameEntity playerEntity)
		{
			Assert.IsTrue(cardEntity.hasGameCard);

			MoveCard(cardEntity, playerEntity, false);
		}

		public static void MoveCardInToBox(CardEntity cardEntity)
		{
			Assert.IsFalse(cardEntity.hasGameInBox);

			MoveCard(cardEntity, cardEntity.gameOwner.Entity, true);
		}

		public static void MoveCardOutFromBox(CardEntity cardEntity)
		{
			Assert.IsTrue(cardEntity.hasGameInBox);

			MoveCard(cardEntity, cardEntity.gameOwner.Entity, false);
		}

		public static void MoveCardToShareDeck(CardEntity cardEntity)
		{
			MoveCard(cardEntity, null, false);
		}

		public void Decode(int cardId, int playerId, int isInBox)
		{
			CardEntity = Contexts.sharedInstance.card.GetEntitiesWithGameId(cardId)
				.First();

			TargetPlayerEntity = playerId == 0
				? null
				: Contexts.sharedInstance.game.GetEntities(GameMatcher.GamePlayer)
					.Where(e => e.gamePlayer.PlayerId == playerId)
					.First();

			IsInBox = isInBox != 0;
		}
	}

	public class EventMoveCardSystem : GameEventSystem
	{
		public EventMoveCardSystem(Contexts contexts) : base(contexts) { }

		protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
		{
			return context.CreateCollector(GameEventMatcher.GameEventMoveCard, GroupEvent.Added);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.hasGameEventMoveCard;
		}

		protected override void Process(GameEventEntity entity)
		{
			var e = entity.gameEventMoveCard;

			if (e.TargetPlayerEntity != null)
			{
				e.CardEntity.ReplaceGameOwner(e.TargetPlayerEntity);
			}
			else
			{
				e.CardEntity.RemoveGameOwner();
			}

			if (e.IsInBox)
			{
				e.CardEntity.AddGameInBox(0);
			}
			else
			{
				if (e.CardEntity.hasGameInBox)
				{
					e.CardEntity.RemoveGameInBox();
				}
			}
		}
	}
}
