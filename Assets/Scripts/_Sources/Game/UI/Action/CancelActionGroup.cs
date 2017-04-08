using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Game.UI
{
	[Serializable]
	public class CancelActionGroup : ActionGroup
	{
		public Button CancelButton;

		private Button[] _buttons;
		public override Button[] Buttons
		{
			get
			{
				if (_buttons == null)
					_buttons = new[] { CancelButton };
				return _buttons;
			}
		}

		public void SetAction(UnityAction onCancel)
		{
			CancelButton.onClick.AddListener(onCancel);
		}

		protected override void Hide()
		{
			CancelButton.gameObject.SetActive(false);
			CancelButton.onClick.RemoveAllListeners();
		}

		protected override void Show()
		{
			CancelButton.gameObject.SetActive(true);
			CancelButton.onClick.AddListener(CloseAction);
		}
	}

}
