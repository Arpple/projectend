using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game
{
	public interface IOnDeadAbility
	{
		void OnDead(GameEntity deadEntity);
	}
}

