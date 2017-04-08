using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	[Serializable]
	public class SkillCardActionGroup : ActiveCardActionGroup
	{
		public Button CancelButton;

		private Button[] _buttons;
		public override Button[] Buttons
		{
			get
			{
				if (_buttons == null)
					_buttons = new Button[] { CancelButton };
				return _buttons;
			}
		}

		protected override void SetActionForCard(CardObject card)
		{
			CancelButton.onClick.AddListener(() => CloseAction());
			ShowCardTarget(card);
		}
	}
}
