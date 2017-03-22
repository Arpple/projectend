using System;
using UnityEngine.Assertions;

namespace End.Game
{
	public class AbilityMove : TargetAbility
	{
		public override GameEntity[] GetTileEntityInArea(GameEntity caster)
		{
			return AreaSelector.GetMovePathInRange(caster, caster.unitStatus.MoveSpeed);
		}

		public override GameEntity GetTarget(GameEntity position)
		{
			return position.isTileMovable ? position : null;
		}

		public override void ApplyAbilityEffect(GameEntity caster, GameEntity target)
		{
			EventMove.Create(caster, target.mapPosition);
		}
	}

}
