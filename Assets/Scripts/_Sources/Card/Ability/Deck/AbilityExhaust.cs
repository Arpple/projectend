public class AbilityExhaust : ActiveAbility<UnitEntity>
{
	public override TileEntity[] GetTilesArea(UnitEntity caster)
	{
		return TileAreaSelector.GetAllInRange(caster.GetTileOfUnit(), caster.unitStatus.VisionRange);
	}

	public override UnitEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile)
	{
		return GetEnemyUnitFromTile(caster, tile);
	}

	public override void OnTargetSelected(UnitEntity caster, UnitEntity target)
	{
		var buff = Contexts.sharedInstance.buff.CreateBuff(Buff.Exhaust);
		buff.isBuffExhaust = true;
		target.AddBuff(buff);
	}
}