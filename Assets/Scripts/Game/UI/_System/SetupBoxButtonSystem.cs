using System;
using System.Collections;
using System.Collections.Generic;
using End.Game.UI;
using UnityEngine;

namespace End.Game.UI
{
	public class SetupBoxButtonSystem : ActionButtonSystem
	{
		public SetupBoxButtonSystem(Contexts contexts, ActionButton button) : base(contexts, button)
		{
		}

		public override void Initialize()
		{
			//TODO: setup button
			_button.OnClickCallback += () => Debug.Log("Box");
		}
	}

}
