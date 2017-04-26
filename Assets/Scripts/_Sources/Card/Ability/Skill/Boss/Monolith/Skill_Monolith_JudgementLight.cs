using UnityEngine;

public class Skill_Monolith_JudgementLight : ActiveAbility<UnitEntity> , IAbilityAnimation
{
    public override UnitEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile) {
        return GetEnemyUnitFromTile(caster, tile);
    }

    public override TileEntity[] GetTilesArea(UnitEntity caster) {
        return TileAreaSelector.GetAllInRange(caster.GetTileOfUnit(), 100);
    }

    public override void OnTargetSelected(UnitEntity caster, UnitEntity target)
	{
		Debug.Log("Judgement Light");
		var targets = caster.GetEntitiesInRange(100);
		foreach(var t in targets)
		{
            t.TakeDamage(caster.unitStatus.AttackPower);
        }
	}

    private void dealDamage() {

    }

    public void PlayAnimation(AbilityEffect effect, UnitEntity caster, UnitEntity target) {
        var targets = caster.GetEntitiesInRange(100);
        foreach(var t in targets) {
            var beam = Object.Instantiate(effect,t.view.GameObject.transform,false).GetComponent<AbilityEffect>();
            beam.PlayAnimation();
        }
    }
}