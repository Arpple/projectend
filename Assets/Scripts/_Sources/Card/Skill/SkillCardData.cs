using UnityEngine;

[CreateAssetMenu(menuName = "End/Card - Skill", fileName = "new_card.asset")]
public class SkillCardData : CardData, IIndexData<SkillCard>
{
	[Header("SkillCard")]
	public SkillCard Type;
	[Space]
	public string AbilityClassFullName;

	public SkillCard GetIndex()
	{
		return Type;
	}

	public bool IsIndexEquals(SkillCard index)
	{
		return Type == index;
	}
}