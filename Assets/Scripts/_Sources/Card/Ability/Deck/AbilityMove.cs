public class AbilityMove : ActiveAbility<TileEntity>
{
	private MapPositionComponent _targetPosition;

	public override TileEntity[] GetTilesArea(UnitEntity caster)
	{
		return TileAreaSelector.GetMovePathInRange(caster.GetTileOfUnit(), caster.unitStatus.MoveSpeed);
	}

	public override TileEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile)
	{
		return tile;
	}

	public override void OnTargetSelected(UnitEntity caster, TileEntity target)
	{
		caster.ReplaceMapPosition(target.mapPosition.x, target.mapPosition.y);
	}
}