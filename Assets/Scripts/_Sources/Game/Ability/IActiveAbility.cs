using UnityEngine;
using System.Collections;

namespace End.Game
{
	public interface IActiveAbility
	{
		/// <summary>
		/// Gets the tiles to show area of ability.
		/// </summary>
		/// <param name="caster">The caster.</param>
		/// <returns></returns>
		GameEntity[] GetTilesArea(GameEntity caster);

		/// <summary>
		/// Gets a target for each tile in area
		/// </summary>
		/// <param name="caster">The caster.</param>
		/// <param name="targetTile">The target tile.</param>
		/// <returns>target entity or null if this tile can't be target</returns>
		GameEntity GetTargetEntity(GameEntity caster, GameEntity targetTile);

		/// <summary>
		/// Called when [target selected].
		/// </summary>
		/// <param name="caster">The caster.</param>
		/// <param name="target">The target.</param>
		void OnTargetSelected(GameEntity caster, GameEntity target);
	}
}
