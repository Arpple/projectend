using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class AbilityRecover : ActiveAbility<GameEntity>, IReviveAbility
	{
		public override TileEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetAllInRange(caster.GetTileOfUnit(), caster.gameUnitStatus.VisionRange, true);
		}

		public override GameEntity GetTargetFromSelectedTile(GameEntity caster, TileEntity tile)
		{
			return tile.GetUnitOnTile();
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
