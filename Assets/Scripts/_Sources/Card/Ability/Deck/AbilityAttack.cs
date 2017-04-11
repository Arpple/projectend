public class AbilityAttack : ActiveAbility<UnitEntity>
{
	private MapPositionComponent _targetPosition;

	public override TileEntity[] GetTilesArea(UnitEntity caster)
	{
		return TileAreaSelector.GetAllInRange(caster.GetTileOfUnit(), caster.unitStatus.AttackRange);
	}

	public override UnitEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile)
	{
		var targetUnit = tile.GetUnitOnTile();

		if (targetUnit == null) return null;

		return targetUnit.owner.Entity != caster.owner.Entity ? targetUnit : null;
	}

	public override void OnTargetSelected(UnitEntity caster, UnitEntity target)
	{
		target.TakeFatalDamage(caster.unitStatus.AttackPower);
	}
}