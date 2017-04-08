using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	[Serializable]
	public class SkillCardActionGroup : CardActionGroup
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

		public override void SetAction(CardObject card)
		{
			CancelButton.onClick.AddListener(() => CloseAction());
			ShowCardTarget(card);
		}

		public void MoveToBox(CardObject card)
		{
			EventMoveCard.MoveCardInToBox(card.Entity);
			CloseAction();
		}
	}
}
