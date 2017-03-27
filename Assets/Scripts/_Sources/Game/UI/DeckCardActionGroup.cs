using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace End.Game.UI
{
	[Serializable]
	public class DeckCardActionGroup : ICardActionGroup
	{
		public Button ActiveButton;
		public Button BoxButton;
		public Button CancelButton;

		public Button[] Buttons
		{
			get
			{
				if (_buttons == null)
					_buttons = new Button[] { ActiveButton, BoxButton, CancelButton };
				return _buttons;
			}
		}

		private Button[] _buttons;

		public event GroupCloseHandler OnGroupClosed;

		public void CloseAction()
		{
			foreach(var btn in Buttons)
			{
				btn.gameObject.SetActive(false);
			}

			if (OnGroupClosed != null) OnGroupClosed();
		}

		public void ShowAction(CardObject card)
		{
			foreach (var btn in Buttons)
			{
				btn.onClick.RemoveAllListeners();
				btn.gameObject.SetActive(true);
			}

			ActiveButton.onClick.AddListener(() => Debug.Log("Use " + card));
			BoxButton.onClick.AddListener(() => Debug.Log("Move to box " + card));
			CancelButton.onClick.AddListener(() => CloseAction());
		}
	}

}
