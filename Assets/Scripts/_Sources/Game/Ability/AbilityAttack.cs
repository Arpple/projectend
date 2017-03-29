using System;
using UnityEngine.Assertions;

namespace End.Game
{
	public class AbilityAttack : Ability, ITargetAbility
	{
		private GameEntity _caster;
		private MapPositionComponent _targetPosition;

		public GameEntity[] GetTilesArea(GameEntity caster)
		{
			_caster = caster;
			return AreaSelector.GetAllInRange(caster.mapPosition.GetTile(), caster.unitStatus.AttackRange);
		}

		public GameEntity GetTargetEntity(GameEntity tile)
		{
			var targetUnit = tile.GetUnitOnTile();

			if (targetUnit == null) return targetUnit;

			return targetUnit.unit.OwnerEntity != _caster.unit.OwnerEntity ? targetUnit : null;
		}

		public void OnTargetSelected(GameEntity target)
		{
			EventHitpointModify.Create(_caster, target, _caster.unitStatus.AttackPower, HitPointModifyType.FatalDamage);
		}
	}

}
