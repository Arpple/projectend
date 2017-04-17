using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ResourceCardSetting
{
	public List<ResourceCardData> ResourceCardsData;
	private CacheList<Resource, ResourceCardData> _cacheData;

	public ResourceCardSetting()
	{
		_cacheData = new CacheList<Resource, ResourceCardData>();
	}

	public ResourceCardData GetCardData(Resource card)
	{
		var data = _cacheData.Get(card, (c) => ResourceCardsData.FirstOrDefault(d => d.Type == card));
		if (data == null) throw new MissingReferenceException("Card data not found : " + card.ToString());
		return data;
	}
}