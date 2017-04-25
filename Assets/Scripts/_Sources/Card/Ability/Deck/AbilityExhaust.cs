public class AbilityExhaust : ActiveAbility<UnitEntity>
{
    private UnitEntity _caster, _target;
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
        target.AddAbilityAggressiveEvent(target, 1, CastExhaust);
	}
    
    private void CastExhaust() {
        var buff = Contexts.sharedInstance.buff.CreateBuff(Buff.Exhaust);
        buff.isBuffExhaust = true;
        _target.AddBuff(buff);
    }
}