using Entitas;
using System.Linq;

namespace End.Game
{
	[Game]
	public class InBoxComponent : IComponent
	{
		public int Index;
	}

	public static class BoxCardExtension
	{
		public static GameEntity[] GetBoxCards(this GameContext context)
		{
			return context.GetEntities(GameMatcher.InBox);
		}

		public static GameEntity[] GetPlayerBoxCards(this GameContext context, GameEntity playerEntity)
		{
			return context.GetBoxCards()
				.Where(c => c.playerCard.OwnerEntity == playerEntity)
				.ToArray();
		}

		public static GameEntity[] GetPlayerBoxCards<T>(this GameContext context, GameEntity playerEntity)
		{
			return context.GetBoxCards()
				.Where(c => c.playerCard.OwnerEntity == playerEntity)
				.Where(boxCard => boxCard.ability.Ability is T)
				.ToArray();
		}
	}
}
