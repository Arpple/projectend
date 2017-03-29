using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game
{
	public interface IOnDeadAbility
	{
		/// <summary>
		/// apply effect when entity dead
		/// </summary>
		/// <param name="deadEntity">The dead entity.</param>
		void OnDead(GameEntity deadEntity);
	}
}

