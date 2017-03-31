using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

namespace End.Game
{
	[GameEvent]
	public class EventUseCardOnTile : GameEventComponent, IRemoteEvent
	{
		public GameEntity UserEntity;
		public GameEntity CardEnttiy;
		public GameEntity TargetEnttiy;

		public static void Create(GameEntity userEntity, GameEntity cardEntity, GameEntity tileEntity)
		{
			Assert.IsTrue(userEntity.hasUnit);
			Assert.IsTrue(cardEntity.hasCard);
			Assert.IsTrue(tileEntity.hasTile);

			GameEvent.CreateEvent<EventUseCardOnTile>(userEntity.unit.Id, cardEntity.card.Id, tileEntity.mapPosition.x, tileEntity.mapPosition.y);
		}

		public void Decode(int userUnitId, int cardId, int x, int y)
		{
			UserEntity = Contexts.sharedInstance.game.GetEntities(GameMatcher.Unit)
				.Where(u => u.unit.Id == userUnitId)
				.First();

			CardEnttiy = Contexts.sharedInstance.game.GetEntities(GameMatcher.Card)
				.Where(c => c.card.Id == cardId)
				.First();

			TargetEnttiy = Contexts.sharedInstance.game.GetEntities(GameMatcher.Tile)
				.Where(t => t.mapPosition.x == x && t.mapPosition.y == y)
				.First();
		}
	}

	public class EventUseCardOnTileSystem : GameEventSystem
	{
		public EventUseCardOnTileSystem(Contexts contexts) : base(contexts)
		{
		}

		protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
		{
			return context.CreateCollector(GameEventMatcher.EventUseCardOnTile, GroupEvent.Added);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.hasEventUseCardOnTile;
		}

		protected override void Process(GameEventEntity entity)
		{
			var cardEvent = entity.eventUseCardOnTile;
			var ability = (ITargetAbility)cardEvent.CardEnttiy.ability.Ability;
			ability.OnTargetSelected(cardEvent.TargetEnttiy);

			EventMoveCard.MoveCardToShareDeck(cardEvent.CardEnttiy);
		}
	}
}
