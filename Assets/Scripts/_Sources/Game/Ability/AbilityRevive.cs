using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game
{
	public class AbilityRevive : Ability, IOnDeadAbility, ITargetAbility
	{
		public GameEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetAllInRange(caster.mapPosition.GetTile(), caster.unitStatus.VisionRange);
		}

		public GameEntity GetTargetEntity(GameEntity targetTile)
		{
			return targetTile.GetUnitOnTile();
		}

		public void OnDead(GameEntity deadEntity)
		{
			OnTargetSelected(deadEntity);
		}

		public void OnTargetSelected(GameEntity target)
		{
			target.ModifyHitpoint(1);
			target.isDead = false;
		}

		
	}

}
