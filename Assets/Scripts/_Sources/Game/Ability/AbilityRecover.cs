using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game
{
	public class AbilityRecover : Ability, IOnDeadAbility, ITargetAbility
	{
		private GameEntity _caster;

		public GameEntity[] GetTilesArea(GameEntity caster)
		{
			_caster = caster;
			return AreaSelector.GetAllInRange(caster.mapPosition.GetTile(), caster.unitStatus.VisionRange, true);
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
			EventHitpointModify.Create(_caster, target, 1, HitPointModifyType.Recovery);
		}
	}

}
