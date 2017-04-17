using UnityEngine;

[CreateAssetMenu(menuName = "End/Card - Skill", fileName = "new_card.asset")]
public class SkillCardData : CardData
{
	[Header("SkillCard")]
	public SkillCard Type;
	[Space]
	public string AbilityClassFullName;
}