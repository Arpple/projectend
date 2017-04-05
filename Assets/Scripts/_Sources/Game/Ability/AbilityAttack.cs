using System;
using UnityEngine.Assertions;

namespace Game
{
	public class AbilityAttack : ActiveAbility<GameEntity>
	{
		private MapPositionComponent _targetPosition;

		public override TileEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetAllInRange(caster.GetTileOfUnit(), caster.gameUnitStatus.AttackRange);
		}

		public override GameEntity GetTargetFromSelectedTile(GameEntity caster, TileEntity tile)
		{
			var targetUnit = tile.GetUnitOnTile();

			if (targetUnit == null) return null;

			return targetUnit.gameUnit.OwnerEntity != caster.gameUnit.OwnerEntity ? targetUnit : null;
		}

		public override void OnTargetSelected(GameEntity caster, GameEntity target)
		{
			target.TakeFatalDamage(caster.gameUnitStatus.AttackPower);
		}
	}
}
