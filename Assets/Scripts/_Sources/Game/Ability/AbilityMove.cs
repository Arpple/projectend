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
			//already filter by selector
			return position;
		}

		public override void ApplyAbilityEffect(GameEntity caster, GameEntity target)
		{
			EventMoveUnit.Create(caster, target.mapPosition);
		}
	}

}
