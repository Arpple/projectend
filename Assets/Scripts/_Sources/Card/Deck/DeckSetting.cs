using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DeckSetting
{
	public int StartCardCount;
	public int StartTurnDrawCount;
	public DeckData Deck;

	public List<DeckCardData> DeckCardsData;
	private CacheList<DeckCard, DeckCardData> _cacheData;

	public DeckSetting()
	{
		_cacheData = new CacheList<DeckCard, DeckCardData>();
	}

	public DeckCardData GetCardData(DeckCard card)
	{
		var data = _cacheData.Get(card, (c) => DeckCardsData.FirstOrDefault(d => d.Type == card));
		if (data == null) throw new MissingReferenceException("Card data not found : " + card.ToString());
		return data;
	}
}