using System;
using UnityEngine;

namespace End.Game
{
	public abstract class Ability
	{
		public abstract void ActivateAbility(GameEntity caster);
	}
}
