using Entitas;
using System.Linq;

namespace Game
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
			return context.GetEntities(GameMatcher.GameInBox);
		}

		public static GameEntity[] GetPlayerBoxCards(this GameContext context, GameEntity playerEntity)
		{
			return context.GetBoxCards()
				.Where(c => c.gameOwner.Entity == playerEntity)
				.ToArray();
		}

		public static GameEntity[] GetPlayerBoxCards<T>(this GameContext context, GameEntity playerEntity)
		{
			return context.GetBoxCards()
				.Where(c => c.gameOwner.Entity == playerEntity)
				.Where(boxCard => boxCard.gameAbility.Ability is T)
				.ToArray();
		}
	}
}
