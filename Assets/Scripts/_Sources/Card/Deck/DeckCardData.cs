﻿using UnityEngine;

[CreateAssetMenu(menuName = "End/Card/Deck", fileName = "new_card.asset")]
public class DeckCardData : CardData, IIndexData<DeckCard>
{
	[Header("DeckCard")]
	public DeckCard Type;
	public int CreateCount;
	[Space]
	public string AbilityClassFullName;
	public AbilityEffect Effect;

	public DeckCard GetIndex()
	{
		return Type;
	}

	public bool IsIndexEquals(DeckCard index)
	{
		return Type == index;
	}
}