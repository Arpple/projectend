using Entitas;
using System.Linq;
using UnityEngine.Assertions;
using System;

namespace End.Game
{
	[GameEvent]
	public class EventMoveCard : GameEventComponent
	{
		public GameEntity CardEntity;
		public int TargetPlayerId;
		public bool IsInBox;

		private static void MoveCard(GameEntity cardEntity, int playerId, bool isMoveTobox)
		{
			Assert.IsTrue(cardEntity.hasCard);

			GameEvent.CreateEvent<EventMoveCard>(cardEntity.card.Id, playerId, isMoveTobox ? 1 : 0);
		}

		public static void MoveCardToPlayer(GameEntity cardEntity, int playerId)
		{
			Assert.IsTrue(cardEntity.hasCard);

			MoveCard(cardEntity, playerId, false);
		}

		public static void MoveCardInToBox(GameEntity cardEntity)
		{
			Assert.IsFalse(cardEntity.hasInBox);

			MoveCard(cardEntity, cardEntity.playerCard.CurrentOwnerId, true);
		}

		public static void MoveCardOutFromBox(GameEntity cardEntity)
		{
			Assert.IsTrue(cardEntity.hasInBox);

			MoveCard(cardEntity, cardEntity.playerCard.CurrentOwnerId, false);
		}

		public static void MoveCardToShareDeck(GameEntity cardEntity)
		{
			MoveCard(cardEntity, 0, false);
		}

		public void Decode(int cardId, int playerId, int isInBox)
		{
			CardEntity = Contexts.sharedInstance.game.GetEntities(GameMatcher.Card)
				.Where(c => c.card.Id == cardId)
				.First();

			TargetPlayerId = playerId;
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

			if (e.TargetPlayerId != 0)
			{
				e.CardEntity.ReplacePlayerCard(e.TargetPlayerId);
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
