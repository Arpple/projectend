using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game
{
	public interface ITargetAbility
	{
		void ShowTarget();
		void OnTargetSelected(GameEntity target);
	}
}