using System;
using UnityEngine.Assertions;

namespace End.Game.UI
{
	[Serializable]
	public class ActionButtonController
	{
		public ActionGroupMain MainAction;
		public ActionGroupCard CardAction;

		public void Awake()
		{
			MainAction.Awake();
			CardAction.Awake();

			CardAction.ToggleVisibility(false);
			MainAction.ToggleVisibility(true);
		}
	}

}
