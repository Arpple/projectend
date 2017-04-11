public class AbilityRecover : ActiveAbility<UnitEntity>, IReviveAbility
{
	public override TileEntity[] GetTilesArea(UnitEntity caster)
	{
		return TileAreaSelector.GetAllInRange(caster.GetTileOfUnit(), caster.unitStatus.VisionRange, true);
	}

	public override UnitEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile)
	{
		return tile.GetUnitOnTile();
	}

	public override void OnTargetSelected(UnitEntity caster, UnitEntity target)
	{
		target.RecoverHitpoint(1);
		target.isDead = false;
	}

	public void OnDead(UnitEntity deadEntity)
	{
		OnTargetSelected(deadEntity, deadEntity);
	}
}