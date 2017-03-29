using System;
using UnityEngine.Assertions;

namespace End.Game
{
	public class AbilityMove : Ability, ITargetAbility
	{
		private GameEntity _caster;
		private MapPositionComponent _targetPosition;

		public GameEntity[] GetTargets(GameEntity caster)
		{
			_caster = caster;
			return AreaSelector.GetMovePathInRange(caster.mapPosition.GetTile(), caster.unitStatus.MoveSpeed);
		}

		public GameEntity GetTargetEntity(GameEntity targetTile)
		{
			return targetTile;
		}

		public void OnTargetSelected(GameEntity target)
		{
			EventMoveUnit.Create(_caster, target.mapPosition);
		}

		
	}

}
