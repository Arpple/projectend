using Entitas;
using System.Linq;

namespace End.Game
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
	}
}
