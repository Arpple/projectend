using System;
using Entitas;

public abstract class ActiveAbility<TTarget> : Ability, IActiveAbility where TTarget : Entity
{
	/// <summary>
	/// Gets the tiles to show area of ability.
	/// </summary>
	/// <param name="caster">The caster.</param>
	/// <returns></returns>
	public abstract TileEntity[] GetTilesArea(UnitEntity caster);

	/// <summary>
	/// Gets a target for each tile in area
	/// </summary>
	/// <param name="caster">The caster.</param>
	/// <param name="tile">The selected tile.</param>
	/// <returns>target entity or null if this tile can't be target</returns>
	public abstract TTarget GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile);

	/// <summary>
	/// Called when [target selected].
	/// </summary>
	/// <param name="caster">The caster.</param>
	/// <param name="target">The target.</param>
	public abstract void OnTargetSelected(UnitEntity caster, TTarget target);

	protected UnitEntity GetEnemyUnitFromTile(UnitEntity caster, TileEntity tile)
	{
		var targetUnit = tile.GetUnitOnTile();
		if (targetUnit == null) return null;
		return targetUnit.owner.Entity != caster.owner.Entity ? targetUnit : null;
	}

}