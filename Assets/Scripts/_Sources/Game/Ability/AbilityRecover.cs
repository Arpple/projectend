using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game
{
	public class AbilityRecover : Ability, IReviveAbility
	{
		public override GameEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetAllInRange(caster.mapPosition.GetTile(), caster.unitStatus.VisionRange, true);
		}

		public override GameEntity GetTargetEntity(GameEntity caster, GameEntity targetTile)
		{
			return targetTile.GetUnitOnTile();
		}

		public override void OnTargetSelected(GameEntity caster, GameEntity target)
		{
			target.RecoverHitpoint(1);
			target.isDead = false;
		}

		public void OnDead(GameEntity deadEntity)
		{
			OnTargetSelected(deadEntity, deadEntity);
		}
	}

}
