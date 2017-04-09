using Entitas;
using System.Linq;
using UnityEngine.Assertions;

namespace Game
{
	[Card]
	public class DeckCardComponent : IComponent
	{}

	public static class DeckCardExtension
	{
		public static CardEntity[] GetDeckCards(this CardContext context)
		{
			return context.GetEntities(CardMatcher.GameDeckCard);
		}

		public static CardEntity[] GetShareDeckCards(this CardContext context)
		{
			return context.GetEntities(CardMatcher.GameDeckCard)
				.Where(c => !c.hasGameOwner)
				.ToArray();
		}

		public static CardEntity[] GetPlayerDeckCards(this CardContext context, GameEntity playerEntity)
		{
			return context.GetDeckCards()
				.Where(c => c.hasGameOwner && c.gameOwner.Entity == playerEntity && !c.hasGameInBox)
				.ToArray();
		}

		public static CardEntity[] GetPlayerDeckCardsIncludeBox(this CardContext context, GameEntity playerEntity)
		{
			return context.GetDeckCards()
				.Where(c => c.hasGameOwner && c.gameOwner.Entity == playerEntity)
				.ToArray();
		}

		public static void MoveCardToDeck(this CardEntity cardEntity)
		{
			Assert.IsTrue(cardEntity.isGameDeckCard);

			cardEntity.RemoveGameOwner();
			RemoveInbox(cardEntity);
		}

		private static void RemoveInbox(CardEntity card)
		{
			if (card.hasGameInBox)
				card.RemoveGameInBox();
		}
	}
}
