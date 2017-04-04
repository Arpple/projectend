using System;
using UnityEngine.Assertions;

namespace Game
{
	public class AbilityMove : Ability, IActiveAbility
	{
		private MapPositionComponent _targetPosition;

		public GameEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetMovePathInRange(caster.gameMapPosition.GetTile(), caster.gameUnitStatus.MoveSpeed);
		}

		public void OnTargetSelected(GameEntity caster, GameEntity target)
		{
			caster.ReplaceGameMapPosition(target.gameMapPosition.x, target.gameMapPosition.y);
		}

		public GameEntity GetTargetEntity(GameEntity caster, GameEntity targetTile)
		{
			return targetTile;
		}
	}

}
