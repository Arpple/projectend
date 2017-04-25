using System.Linq;
using Entitas;

[Card]
public class ResourceCardComponent : IComponent
{
	public Resource Type;
}

public static class ResourceCardExtension {
    public static CardEntity[] GetResourceCards(this CardContext context) {
        return context.GetEntities(CardMatcher.ResourceCard);
    }

    public static CardEntity[] GetShareResourceCards(this CardContext context) {
        return context.GetEntities(CardMatcher.ResourceCard)
            .Where(c => !c.hasOwner)
            .ToArray();
    }

    public static CardEntity[] GetPlayerResourceCards(this CardContext context, GameEntity playerEntity) {
        return context.GetResourceCards()
            .Where(c => c.hasOwner && c.owner.Entity == playerEntity && !c.hasInBox)
            .ToArray();
    }

    public static CardEntity[] GetPlayerResourceCardsIncludeBox(this CardContext context, GameEntity playerEntity) {
        return context.GetResourceCards()
            .Where(c => c.hasOwner && c.owner.Entity == playerEntity)
            .ToArray();
    }
}