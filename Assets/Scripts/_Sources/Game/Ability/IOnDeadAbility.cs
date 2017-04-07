using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public interface IOnDeadAbility
	{
		/// <summary>
		/// apply effect when entity dead
		/// </summary>
		/// <param name="deadEntity">The dead entity.</param>
		void OnDead(UnitEntity deadEntity);
	}
}

