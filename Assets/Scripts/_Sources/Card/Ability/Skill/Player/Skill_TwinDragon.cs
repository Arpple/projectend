using System;

public class Skill_TwinDragon: ActiveAbility<UnitEntity> {
    private UnitEntity _target;
    public override UnitEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile) {
        return GetEnemyUnitFromTile(caster, tile);
    }

    public override TileEntity[] GetTilesArea(UnitEntity caster) {
        return TileAreaSelector.GetAllInRange(caster.GetTileOfUnit(), caster.unitStatus.VisionRange*3);
    }

    public override void OnTargetSelected(UnitEntity caster, UnitEntity target) {
        this._target = target;
        target.AddAbilityAggressiveEvent(target, 5, twinDragon);
    }

    private void twinDragon() {
        _target.AddAbilityDamage(1, true);
    }
}
