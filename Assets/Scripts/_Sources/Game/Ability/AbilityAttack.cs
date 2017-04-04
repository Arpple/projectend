using System;
using UnityEngine.Assertions;

namespace End.Game
{
	public class AbilityAttack : Ability, IActiveAbility
	{
		private MapPositionComponent _targetPosition;

		public GameEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetAllInRange(caster.mapPosition.GetTile(), caster.unitStatus.AttackRange);
		}

		public GameEntity GetTargetEntity(GameEntity caster, GameEntity targetTile)
		{
			var targetUnit = targetTile.GetUnitOnTile();

			if (targetUnit == null) return targetUnit;

			return targetUnit.unit.OwnerEntity != caster.unit.OwnerEntity ? targetUnit : null;
		}

		public void OnTargetSelected(GameEntity caster, GameEntity target)
		{
			target.TakeFatalDamage(caster.unitStatus.AttackPower);
		}
	}

}
