using System;
using System.Collections;
using System.Collections.Generic;
using End.Game.UI;
using UnityEngine;

namespace End.Game.UI
{
	public class SetupEndButtonSystem : ActionButtonSystem
	{
		public SetupEndButtonSystem(Contexts contexts, ActionButton button) : base(contexts, button)
		{
		}

		public override void Initialize()
		{
			_button.OnClickCallback += () =>
			{
				if (_contexts.game.playingOrder.CurrentPlayerId == GameController.LocalPlayer.PlayerId)
				{
					EventEndTurn.Create();
				}
			};
		}
	}

}
