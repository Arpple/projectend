using System.Linq;
using Entitas;
using UnityEngine.Assertions;

public static class DeckCardExtension
{
	public static CardEntity[] GetDeckCards(this CardContext context)
	{
		return context.GetEntities(CardMatcher.DeckCard);
	}

	public static CardEntity[] GetShareDeckCards(this CardContext context)
	{
		return context.GetEntities(CardMatcher.DeckCard)
			.Where(c => !c.hasOwner)
			.ToArray();
	}

	public static CardEntity[] GetPlayerDeckCards(this CardContext context, GameEntity playerEntity)
	{
		return context.GetDeckCards()
			.Where(c => c.hasOwner && c.owner.Entity == playerEntity && !c.hasInBox)
			.ToArray();
	}

	public static CardEntity[] GetPlayerDeckCardsIncludeBox(this CardContext context, GameEntity playerEntity)
	{
		return context.GetDeckCards()
			.Where(c => c.hasOwner && c.owner.Entity == playerEntity)
			.ToArray();
	}

	public static void MoveCardToDeck(this CardEntity cardEntity)
	{
		cardEntity.RemoveOwner();
		RemoveInbox(cardEntity);
	}

	private static void RemoveInbox(CardEntity card)
	{
		if (card.hasInBox)
			card.RemoveInBox();
	}
}