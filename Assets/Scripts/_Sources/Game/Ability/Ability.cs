using System;
using UnityEngine;

namespace End.Game
{
	public abstract class Ability
	{
		/// <summary>
		/// Activates the ability.
		/// </summary>
		/// <param name="caster">The caster.</param>
		public abstract void ActivateAbility(GameEntity caster, Action callback);
	}
}
