using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "End/Boss", fileName = "new_boss.asset")]
public class BossData : UnitData
{
	[Header("--Boss--")]
	public Boss Type;

	[Header("Skill")]
	public List<Card> SkillCards;
}
