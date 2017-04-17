using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class SkillCardSetting
{
	public List<SkillCardData> SkillCardsData;
	private CacheList<SkillCard, SkillCardData> _cacheData;

	public SkillCardSetting()
	{
		_cacheData = new CacheList<SkillCard, SkillCardData>();
	}

	public SkillCardData GetCardData(SkillCard card)
	{
		var data = _cacheData.Get(card, (c) => SkillCardsData.FirstOrDefault(d => d.Type == card));
		if (data == null) throw new MissingReferenceException("Card data not found : " + card.ToString());
		return data;
	}
}