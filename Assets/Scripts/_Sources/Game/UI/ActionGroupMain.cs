using System;
using UnityEngine.Assertions;

namespace End.Game.UI
{
	[Serializable]
	public class ActionGroupMain : ActionButtonGroup
	{
		public ActionButton EndButton;
		public ActionButton BoxButton;
		public ActionButton CardButton;
		public ActionButton SkillButton;
		public ActionButton TurnButton;

		public void Awake()
		{
			AllActions = new ActionButton[] { EndButton, BoxButton, CardButton, SkillButton, TurnButton };
			foreach (var a in AllActions)
			{
				Assert.IsNotNull(a);
			}
		}
	}
}
