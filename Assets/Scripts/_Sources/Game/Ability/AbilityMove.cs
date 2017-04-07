using System;
using UnityEngine.Assertions;

namespace Game
{
	public class AbilityMove : ActiveAbility<TileEntity>
	{
		private MapPositionComponent _targetPosition;

		public override TileEntity[] GetTilesArea(UnitEntity caster)
		{
			return TileAreaSelector.GetMovePathInRange(caster.GetTileOfUnit(), caster.gameUnitStatus.MoveSpeed);
		}

		public override TileEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile)
		{
			return tile;
		}

		public override void OnTargetSelected(UnitEntity caster, TileEntity target)
		{
			caster.ReplaceGameMapPosition(target.gameMapPosition.x, target.gameMapPosition.y);
		}
	}
}
