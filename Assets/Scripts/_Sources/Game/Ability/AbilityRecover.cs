using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class AbilityRecover : ActiveAbility<GameEntity>, IReviveAbility
	{
		public override GameEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetAllInRange(caster.gameMapPosition.GetTile(), caster.gameUnitStatus.VisionRange, true);
		}

		public override GameEntity GetTargetEntity(GameEntity caster, GameEntity targetTile)
		{
			return targetTile.GetUnitOnTile();
		}

		public override void OnTargetSelected(GameEntity caster, GameEntity target)
		{
			target.RecoverHitpoint(1);
			target.isGameDead = false;
		}

		public void OnDead(GameEntity deadEntity)
		{
			OnTargetSelected(deadEntity, deadEntity);
		}
	}

}
