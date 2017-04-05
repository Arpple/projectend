using UnityEngine;
using System.Collections;
using Entitas;

namespace Game
{
	public abstract class ActiveAbility<TTarget> : Ability where TTarget : Entity
	{
		/// <summary>
		/// Gets the tiles to show area of ability.
		/// </summary>
		/// <param name="caster">The caster.</param>
		/// <returns></returns>
		public abstract TileEntity[] GetTilesArea(GameEntity caster);

		/// <summary>
		/// Gets a target for each tile in area
		/// </summary>
		/// <param name="caster">The caster.</param>
		/// <param name="tile">The selected tile.</param>
		/// <returns>target entity or null if this tile can't be target</returns>
		public abstract TTarget GetTargetFromSelectedTile(GameEntity caster, TileEntity tile);

		/// <summary>
		/// Called when [target selected].
		/// </summary>
		/// <param name="caster">The caster.</param>
		/// <param name="target">The target.</param>
		public abstract void OnTargetSelected(GameEntity caster, TTarget target);
	}
}
