using System;
using UnityEngine.Assertions;

namespace Game
{
	public class AbilityMove : ActiveAbility<GameEntity>
	{
		private MapPositionComponent _targetPosition;

		public override GameEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetMovePathInRange(caster.gameMapPosition.GetTile(), caster.gameUnitStatus.MoveSpeed);
		}

		public override void OnTargetSelected(GameEntity caster, GameEntity target)
		{
			caster.ReplaceGameMapPosition(target.gameMapPosition.x, target.gameMapPosition.y);
		}

		public override GameEntity GetTargetEntity(GameEntity caster, GameEntity targetTile)
		{
			return targetTile;
		}
	}

}
