using System;
using UnityEngine.Assertions;

namespace Game
{
	public class AbilityAttack : ActiveAbility<GameEntity>
	{
		private MapPositionComponent _targetPosition;

		public override GameEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetAllInRange(caster.gameMapPosition.GetTile(), caster.gameUnitStatus.AttackRange);
		}

		public override GameEntity GetTargetEntity(GameEntity caster, GameEntity targetTile)
		{
			var targetUnit = targetTile.GetUnitOnTile();

			if (targetUnit == null) return targetUnit;

			return targetUnit.gameUnit.OwnerEntity != caster.gameUnit.OwnerEntity ? targetUnit : null;
		}

		public override void OnTargetSelected(GameEntity caster, GameEntity target)
		{
			target.TakeFatalDamage(caster.gameUnitStatus.AttackPower);
		}
	}

}
