using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "End/Character", fileName = "new_character.asset")]
public class CharacterData : UnitData, IIndexData<Character>
{
	[Header("--Character--")]
	public Character Type;

	[Header("CharacterSkill")]
	public List<SkillCard> SkillCards;

	public Character GetIndex()
	{
		return Type;
	}

	public bool IsIndexEquals(Character index)
	{
		return Type == index;
	}
}
