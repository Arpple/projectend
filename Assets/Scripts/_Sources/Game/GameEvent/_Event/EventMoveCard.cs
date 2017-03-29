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

		public static void MoveCardToPlayer(GameEntity cardEntity, int playerId)
		{
			Assert.IsTrue(cardEntity.hasCard);

			GameEvent.CreateEvent<EventMoveCard>(cardEntity.card.Id, playerId);
		}

		public static void MoveCardToShareDeck(GameEntity cardEntity)
		{
			Assert.IsTrue(cardEntity.hasCard);

			GameEvent.CreateEvent<EventMoveCard>(cardEntity.card.Id, 0);
		}

		public void Decode(int cardId, int playerId)
		{
			CardEntity = Contexts.sharedInstance.game.GetEntities(GameMatcher.Card)
				.Where(c => c.card.Id == cardId)
				.First();

			this.TargetPlayerId = playerId;
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

			if (e.CardEntity.hasInBox)
			{
				e.CardEntity.RemoveInBox();
			}

			if (e.TargetPlayerId != 0)
			{
				e.CardEntity.ReplacePlayerCard(e.TargetPlayerId);
			}
			else
			{
				e.CardEntity.RemovePlayerCard();
			}
		}
	}
}
