using Entitas;
using System.Linq;

namespace Game
{
	[Card]
	public class InBoxComponent : IComponent
	{
		public int Index;
	}

	public static class BoxCardExtension
	{
		public static CardEntity[] GetBoxCards(this CardContext context)
		{
			return context.GetEntities(CardMatcher.GameInBox);
		}

		public static CardEntity[] GetPlayerBoxCards(this CardContext context, GameEntity playerEntity)
		{
			return context.GetBoxCards()
				.Where(c => c.gameOwner.Entity == playerEntity)
				.ToArray();
		}

		public static CardEntity[] GetPlayerBoxCards<T>(this CardContext context, GameEntity playerEntity)
		{
			return context.GetBoxCards()
				.Where(c => c.gameOwner.Entity == playerEntity)
				.Where(boxCard => boxCard.gameAbility.Ability is T)
				.ToArray();
		}
	}
}
