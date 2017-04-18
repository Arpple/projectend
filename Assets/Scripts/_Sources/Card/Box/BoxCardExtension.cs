using System.Linq;
using Entitas;

public static class BoxCardExtension
{
	public static CardEntity[] GetBoxCards(this CardContext context)
	{
		return context.GetEntities(CardMatcher.InBox);
	}

	public static CardEntity[] GetPlayerBoxCards(this CardContext context, GameEntity playerEntity)
	{
		return context.GetBoxCards()
			.Where(c => c.owner.Entity == playerEntity)
			.ToArray();
	}

	public static CardEntity[] GetPlayerBoxCards<T>(this CardContext context, GameEntity playerEntity)
	{
		return context.GetBoxCards()
			.Where(c => c.owner.Entity == playerEntity)
			.Where(boxCard => boxCard.ability.Ability is T)
			.ToArray();
	}
}