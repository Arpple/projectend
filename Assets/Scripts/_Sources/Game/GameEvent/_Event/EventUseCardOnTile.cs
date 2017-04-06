using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game
{
	[GameEvent]
	public class EventUseCardOnTile : GameEventComponent
	{
		public GameEntity UserEntity;
		public CardEntity CardEnttiy;
		public TileEntity TargetEnttiy;

		public static void Create(GameEntity userEntity, CardEntity cardEntity, TileEntity tileEntity)
		{
			Assert.IsTrue(userEntity.hasGameUnit);
			Assert.IsTrue(cardEntity.hasGameCard);
			Assert.IsTrue(tileEntity.hasGameTile);

			GameEvent.CreateEvent<EventUseCardOnTile>(userEntity.gameUnit.Id, cardEntity.gameId.Id, tileEntity.gameMapPosition.x, tileEntity.gameMapPosition.y);
		}

		public void Decode(int userUnitId, int cardId, int x, int y)
		{
			UserEntity = Contexts.sharedInstance.game.GetEntities(GameMatcher.GameUnit)
				.Where(u => u.gameUnit.Id == userUnitId)
				.First();

			CardEnttiy = Contexts.sharedInstance.card.GetEntitiesWithGameId(cardId)
				.First();

			TargetEnttiy = Contexts.sharedInstance.tile.GetEntitiesWithGameMapPosition(new Position(x, y))
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
			return context.CreateCollector(GameEventMatcher.GameEventUseCardOnTile, GroupEvent.Added);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.hasGameEventUseCardOnTile;
		}

		protected override void Process(GameEventEntity entity)
		{
			var cardEvent = entity.gameEventUseCardOnTile;
			var ability = (ActiveAbility<TileEntity>)cardEvent.CardEnttiy.gameAbility.Ability;
			ability.OnTargetSelected(cardEvent.UserEntity, cardEvent.TargetEnttiy);

			if (cardEvent.CardEnttiy.isGameDeckCard)
				RemovePlayerCard(cardEvent.CardEnttiy);
		}

		private void RemovePlayerCard(CardEntity card)
		{
			card.RemoveGameOwner();
			if (card.hasGameInBox) card.RemoveGameInBox();
		}
	}
}
