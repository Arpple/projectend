using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class TestDiscard : SelfActiveAbility, IDiscardCardAbility
	{
		public int Count
		{
			get { return 1; }
		}

		public override void OnTargetSelected(UnitEntity caster, UnitEntity target)
		{
			Debug.Log("Success");
		}
	}
}
