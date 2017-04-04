using Entitas;
using System.Linq;
using UnityEngine.Assertions;
using System;

namespace Game
{
	[GameEvent]
	public class EventMoveCard : GameEventComponent
	{
		public GameEntity CardEntity;
		public GameEntity TargetPlayerEntity;
		public bool IsInBox;

		private static void MoveCard(GameEntity cardEntity, GameEntity playerEntity, bool isMoveTobox)
		{
			Assert.IsTrue(cardEntity.hasCard);

			GameEvent.CreateEvent<EventMoveCard>(
				cardEntity.card.Id, 
				playerEntity != null 
					? playerEntity.player.PlayerId 
					: 0, 
				isMoveTobox 
					? 1 
					: 0
			);
		}

		public static void MoveCardToPlayer(GameEntity cardEntity, GameEntity playerEntity)
		{
			Assert.IsTrue(cardEntity.hasCard);

			MoveCard(cardEntity, playerEntity, false);
		}

		public static void MoveCardInToBox(GameEntity cardEntity)
		{
			Assert.IsFalse(cardEntity.hasInBox);

			MoveCard(cardEntity, cardEntity.playerCard.OwnerEntity, true);
		}

		public static void MoveCardOutFromBox(GameEntity cardEntity)
		{
			Assert.IsTrue(cardEntity.hasInBox);

			MoveCard(cardEntity, cardEntity.playerCard.OwnerEntity, false);
		}

		public static void MoveCardToShareDeck(GameEntity cardEntity)
		{
			MoveCard(cardEntity, null, false);
		}

		public void Decode(int cardId, int playerId, int isInBox)
		{
			CardEntity = Contexts.sharedInstance.game.GetEntities(GameMatcher.Card)
				.Where(c => c.card.Id == cardId)
				.First();

			TargetPlayerEntity = playerId == 0
				? null
				: Contexts.sharedInstance.game.GetEntities(GameMatcher.Player)
					.Where(e => e.player.PlayerId == playerId)
					.First();

			IsInBox = isInBox != 0;
		}
	}

	public class EventMoveCardSystem : GameEventSystem
	{
		public EventMoveCardSystem(Contexts contexts) : base(contexts) { }

		protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
		{
			return context.CreateCollector(GameEventMatcher.EventMoveCard, GroupEvent.Added);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.hasEventMoveCard;
		}

		protected override void Process(GameEventEntity entity)
		{
			var e = entity.eventMoveCard;

			if (e.TargetPlayerEntity != null)
			{
				e.CardEntity.ReplacePlayerCard(e.TargetPlayerEntity);
			}
			else
			{
				e.CardEntity.RemovePlayerCard();
			}

			if (e.IsInBox)
			{
				e.CardEntity.AddInBox(0);
			}
			else
			{
				if (e.CardEntity.hasInBox)
				{
					e.CardEntity.RemoveInBox();
				}
			}
		}
	}
}
