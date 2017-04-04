using Entitas;
using System.Linq;
using UnityEngine.Assertions;

namespace Game
{
	[Game]
	public class DeckCardComponent : IComponent
	{}

	public static class DeckCardExtension
	{
		public static GameEntity[] GetDeckCards(this GameContext context)
		{
			return context.GetEntities(GameMatcher.DeckCard);
		}

		public static GameEntity[] GetPlayerDeckCards(this GameContext context, GameEntity playerEntity)
		{
			return context.GetDeckCards()
				.Where(c => c.hasPlayerCard && c.playerCard.OwnerEntity == playerEntity && !c.hasInBox)
				.ToArray();
		}

		public static GameEntity[] GetPlayerDeckCardsIncludeBox(this GameContext context, GameEntity playerEntity)
		{
			return context.GetDeckCards()
				.Where(c => c.hasPlayerCard && c.playerCard.OwnerEntity == playerEntity)
				.ToArray();
		}

		public static void MoveCardToDeck(this GameEntity cardEntity)
		{
			Assert.IsTrue(cardEntity.isDeckCard);

			cardEntity.RemovePlayerCard();
			RemoveInbox(cardEntity);
		}

		private static void RemoveInbox(GameEntity card)
		{
			if (card.hasInBox)
				card.RemoveInBox();
		}
	}
}
