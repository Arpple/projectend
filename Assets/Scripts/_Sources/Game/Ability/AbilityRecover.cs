using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class AbilityRecover : ActiveAbility<UnitEntity>, IReviveAbility
	{
		public override TileEntity[] GetTilesArea(UnitEntity caster)
		{
			return AreaSelector.GetAllInRange(caster.GetTileOfUnit(), caster.gameUnitStatus.VisionRange, true);
		}

		public override UnitEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile)
		{
			return tile.GetUnitOnTile();
		}

		public override void OnTargetSelected(UnitEntity caster, UnitEntity target)
		{
			target.RecoverHitpoint(1);
			target.isGameDead = false;
		}

		public void OnDead(UnitEntity deadEntity)
		{
			OnTargetSelected(deadEntity, deadEntity);
		}
	}
}
