using System;
using UnityEngine.Assertions;

namespace Game
{
	public class AbilityMove : ActiveAbility<TileEntity>
	{
		private MapPositionComponent _targetPosition;

		public override TileEntity[] GetTilesArea(GameEntity caster)
		{
			return AreaSelector.GetMovePathInRange(caster.GetTileOfUnit(), caster.gameUnitStatus.MoveSpeed);
		}

		public override TileEntity GetTargetFromSelectedTile(GameEntity caster, TileEntity tile)
		{
			return tile;
		}

		public override void OnTargetSelected(GameEntity caster, TileEntity target)
		{
			caster.ReplaceGameMapPosition(target.gameMapPosition.x, target.gameMapPosition.y);
		}
	}
}
