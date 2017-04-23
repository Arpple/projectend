using System;

public class AbilityMysteryLeaf : ActiveAbility<UnitEntity>
{
    
    public override TileEntity[] GetTilesArea(UnitEntity caster)
	{
		return TileAreaSelector.GetAllInRange(caster.GetTileOfUnit(),caster.unitStatus.VisionRange);
	}

    public override UnitEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile) {
        return GetEnemyUnitFromTile(caster, tile);
    }

    public override void OnTargetSelected(UnitEntity caster, UnitEntity target) {
        if(target.isDead) {
            target.isDead = false;
            target.RecoverHitpoint(1);
        } else {
            target.RecoverHitpoint(3);
        }
    }

}