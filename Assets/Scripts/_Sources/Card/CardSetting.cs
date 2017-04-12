using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class CardSetting
{
	public CardObject CardObjectPrefabs;
	public List<CardData> CardsData;
	public DeckSetting DeckSetting;

	private CacheList<Card, CardData> _cacheData;

	public CardSetting()
	{
		_cacheData = new CacheList<Card, CardData>();
	}

	public CardData GetCardData(Card card)
	{
		var data = _cacheData.Get(card, (c) => CardsData.FirstOrDefault(d => d.Type == card));
		if (data == null) throw new MissingReferenceException("Character data not found : " + card.ToString());
		return data;
	}
}