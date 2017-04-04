using System;
using UnityEngine.Assertions;

namespace End.Game
{
	public class AbilityMove : Ability
	{
		private MapPositionComponent _targetPosition;

		public override GameEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetMovePathInRange(caster.mapPosition.GetTile(), caster.unitStatus.MoveSpeed);
		}

		public override void OnTargetSelected(GameEntity caster, GameEntity target)
		{
			caster.ReplaceMapPosition(target.mapPosition.x, target.mapPosition.y);
		}

		public override GameEntity GetTargetEntity(GameEntity caster, GameEntity targetTile)
		{
			return targetTile;
		}
	}

}
