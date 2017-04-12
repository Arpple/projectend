using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "End/Character", fileName = "new_character.asset")]
public class CharacterData : UnitData
{
	[Header("CharacterSkill")]
	public List<Card> SkillCards;
}
