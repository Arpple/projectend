using System;
using UnityEngine.Assertions;

namespace End.Game
{
	public class AbilityMove : Ability, IActiveAbility
	{
		private MapPositionComponent _targetPosition;

		public GameEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetMovePathInRange(caster.mapPosition.GetTile(), caster.unitStatus.MoveSpeed);
		}

		public void OnTargetSelected(GameEntity caster, GameEntity target)
		{
			caster.ReplaceMapPosition(target.mapPosition.x, target.mapPosition.y);
		}

		public GameEntity GetTargetEntity(GameEntity caster, GameEntity targetTile)
		{
			return targetTile;
		}
	}

}
