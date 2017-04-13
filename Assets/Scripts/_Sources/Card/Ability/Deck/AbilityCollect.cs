public class AbilityCollect : ActiveAbility<TileEntity>
{
	public override TileEntity[] GetTilesArea(UnitEntity caster)
	{
		return TileAreaSelector.GetAllInRange(caster.GetTileOfUnit(), 1, true);
	}

	public override TileEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile)
	{
		return tile.hasCharge && tile.charge.Count > 0 ? tile : null;
	}

	public override void OnTargetSelected(UnitEntity caster, TileEntity target)
	{
		target.ReplaceCharge(target.charge.Count - 1);
	}
}