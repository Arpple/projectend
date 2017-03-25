using System;
using UnityEngine.Assertions;


namespace End.Game.UI
{
	[Serializable]
	public class ActionGroupCard : ActionButtonGroup
	{
		public ActionButton Activate;
		public ActionButton Box;
		public ActionButton Cancel;

		public void Awake()
		{
			AllActions = new ActionButton[] { Activate, Box, Cancel };
			foreach (var a in AllActions)
			{
				Assert.IsNotNull(a);
			}
		}
	}

}
