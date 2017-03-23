using System;
using UnityEngine.Assertions;

namespace End.Game.UI
{
	[Serializable]
	public class ActionButtonGroup
	{
		public ActionButton EndButton;
		public ActionButton BoxButton;
		public ActionButton CardButton;
		public ActionButton SkillButton;
		public ActionButton TurnButton;

		public void Awake()
		{
			Assert.IsTrue(EndButton);
			Assert.IsTrue(BoxButton);
			Assert.IsTrue(CardButton);
			Assert.IsTrue(SkillButton);
			Assert.IsTrue(TurnButton);
		}
	}

}
