public class AbilityAttack : ActiveAbility<UnitEntity>
{
	private MapPositionComponent _targetPosition;

	public override TileEntity[] GetTilesArea(UnitEntity caster)
	{
		return TileAreaSelector.GetAllInRange(caster.GetTileOfUnit(), caster.unitStatus.AttackRange);
	}

	public override UnitEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile)
	{
		return GetEnemyUnitFromTile(caster, tile);
	}

	public override void OnTargetSelected(UnitEntity caster, UnitEntity target)
	{
        target.AddAbilityAttack(caster.unitStatus.AttackPower,1,true);
		//target.TakeFatalDamage(caster.unitStatus.AttackPower);
	}
}