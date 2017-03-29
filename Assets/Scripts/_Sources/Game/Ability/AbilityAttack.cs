using System;
using UnityEngine.Assertions;

namespace End.Game
{
	public class AbilityAttack : Ability, ITargetAbility
	{
		private GameEntity _caster;
		private MapPositionComponent _targetPosition;

		public GameEntity[] GetTargets(GameEntity caster)
		{
			_caster = caster;
			return AreaSelector.GetAllInRange(caster.mapPosition.GetTile(), caster.unitStatus.AttackRange);
		}

		public GameEntity GetTargetEntity(GameEntity tile)
		{
			var unit = tile.GetUnitOnTile();

			if (unit == null) return unit;

			return unit.unit.OwnerPlayer != _caster.unit.OwnerPlayer ? unit : null;
		}

		public void OnTargetSelected(GameEntity target)
		{
			EventDamage.Create(_caster, target, _caster.unitStatus.AttackPower);
		}
	}

}
