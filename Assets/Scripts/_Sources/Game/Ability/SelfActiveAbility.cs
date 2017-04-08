namespace Game
{
	public abstract class SelfActiveAbility : ActiveAbility<UnitEntity>
	{
		public override TileEntity[] GetTilesArea(UnitEntity caster)
		{
			return new[] { caster.GetTileOfUnit() };
		}

		public override UnitEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile)
		{
			return caster;
		}
	}
}
