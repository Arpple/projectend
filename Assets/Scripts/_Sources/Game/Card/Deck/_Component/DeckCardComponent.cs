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
			return context.GetEntities(GameMatcher.GameDeckCard);
		}

		public static GameEntity[] GetPlayerDeckCards(this GameContext context, GameEntity playerEntity)
		{
			return context.GetDeckCards()
				.Where(c => c.hasGameOwner && c.gameOwner.Entity == playerEntity && !c.hasGameInBox)
				.ToArray();
		}

		public static GameEntity[] GetPlayerDeckCardsIncludeBox(this GameContext context, GameEntity playerEntity)
		{
			return context.GetDeckCards()
				.Where(c => c.hasGameOwner && c.gameOwner.Entity == playerEntity)
				.ToArray();
		}

		public static void MoveCardToDeck(this GameEntity cardEntity)
		{
			Assert.IsTrue(cardEntity.isGameDeckCard);

			cardEntity.RemoveGameOwner();
			RemoveInbox(cardEntity);
		}

		private static void RemoveInbox(GameEntity card)
		{
			if (card.hasGameInBox)
				card.RemoveGameInBox();
		}
	}
}
