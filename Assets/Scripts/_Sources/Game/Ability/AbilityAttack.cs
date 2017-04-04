using System;
using UnityEngine.Assertions;

namespace Game
{
	public class AbilityAttack : Ability, IActiveAbility
	{
		private MapPositionComponent _targetPosition;

		public GameEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetAllInRange(caster.gameMapPosition.GetTile(), caster.gameUnitStatus.AttackRange);
		}

		public GameEntity GetTargetEntity(GameEntity caster, GameEntity targetTile)
		{
			var targetUnit = targetTile.GetUnitOnTile();

			if (targetUnit == null) return targetUnit;

			return targetUnit.gameUnit.OwnerEntity != caster.gameUnit.OwnerEntity ? targetUnit : null;
		}

		public void OnTargetSelected(GameEntity caster, GameEntity target)
		{
			target.TakeFatalDamage(caster.gameUnitStatus.AttackPower);
		}
	}

}
