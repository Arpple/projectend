using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game
{
	public interface ITargetAbility
	{
		/// <summary>
		/// Gets the span tiles in ability area.
		/// </summary>
		/// <param name="caster">The caster.</param>
		/// <returns>array of tiles that is in ability area</returns>
		GameEntity[] GetTilesArea(GameEntity caster);

		/// <summary>
		/// Gets the target entity from selected tile entity.
		/// </summary>
		/// <param name="targetTile">ability caster entity.</param>
		/// <param name="targetTile">The target tile entity.</param>
		/// <returns>
		/// target entity or null if tile can't be target.
		/// (still be highlighted)
		/// </returns>
		GameEntity GetTargetEntity(GameEntity caster, GameEntity targetTile);

		/// <summary>
		/// apply ability effect when target selected
		/// </summary>
		/// <param name="targetTile">ability caster entity.</param>
		/// <param name="target">The target entity.</param>
		void OnTargetSelected(GameEntity caster, GameEntity target);
	}
}