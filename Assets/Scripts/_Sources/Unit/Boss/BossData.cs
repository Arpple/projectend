using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "End/Boss", fileName = "new_boss.asset")]
public class BossData : UnitData, IIndexData<Boss>
{
	[Header("--Boss--")]
	public Boss Type;

	[Header("Skill")]
	public List<SkillCard> SkillCards;

	public Boss GetIndex()
	{
		return Type;
	}

	public bool IsIndexEquals(Boss index)
	{
		return Type == index;
	}
}
