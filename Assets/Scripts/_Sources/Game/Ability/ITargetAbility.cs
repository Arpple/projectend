using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game
{
	public interface ITargetAbility
	{
		GameEntity[] GetTargets(GameEntity caster);
		void OnTargetSelected(GameEntity target);
		GameEntity GetTargetEntity(GameEntity targetTile);
	}
}