using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class CharacterSetting
{
	public List<CharacterData> CharactersData;

	private CacheList<Character, CharacterData> _cacheData;

	public CharacterSetting()
	{
		_cacheData = new CacheList<Character, CharacterData>();
	}

	public CharacterData GetCharData(Character cha)
	{
		var data = _cacheData.Get(cha, (c) => CharactersData.FirstOrDefault(d => d.Type == c));
		if (data == null) throw new MissingReferenceException("Character data not found : " + cha.ToString());
		return data;
	}
}

