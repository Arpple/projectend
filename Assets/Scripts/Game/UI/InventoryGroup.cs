using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Game.UI
{
	[Serializable]
	public class InventoryGroup
	{
		public Text Text; //? change name?
		public CardContainer CardContainer;
		public GameObject BoxContainer;
		public GameObject SkillContainer;

		public void Awake()
		{
			Assert.IsNotNull(CardContainer);
			Assert.IsNotNull(BoxContainer);
			Assert.IsNotNull(SkillContainer);
			Assert.IsNotNull(Text);

			CardContainer.Awake();
		}

		public void SetText(string text)
		{
			Text.text = text;
		}
	}

}
