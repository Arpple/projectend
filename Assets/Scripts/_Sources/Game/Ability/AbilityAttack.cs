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

		public bool IsTileTargetable(GameEntity tile)
		{
			var unit = tile.GetUnitOnTile();
			return unit != null
				&& unit.unit.OwnerPlayer != _caster.unit.OwnerPlayer;
		}

		public void OnTargetSelected(GameEntity target)
		{
			EventDamage.Create(_caster, target.GetUnitOnTile(), _caster.unitStatus.AttackPower);
		}
	}

}
