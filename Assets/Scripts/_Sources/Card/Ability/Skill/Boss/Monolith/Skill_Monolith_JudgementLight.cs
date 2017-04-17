using UnityEngine;

public class Skill_Monolith_JudgementLight : SelfActiveAbility
{
	public override void OnTargetSelected(UnitEntity caster, UnitEntity target)
	{
		var targets = caster.GetEntitiesInRange(100);
		foreach(var t in targets)
		{
			t.TakeDamage(caster.unitStatus.AttackPower);
		}
	}
}