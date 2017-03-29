using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace End.Game.UI
{
	[Serializable]
	public class BoxCardActionGroup : ActionGroup, ICardActionGroup
	{
		public Button DiscardButton;
		public Button MoveLeftButton;
		public Button ToDeckButton;
		public Button MoveRightButton;
		public Button CloseBoxButton;

		public Button[] Buttons
		{
			get
			{
				if (_buttons == null)
					_buttons = new Button[] {DiscardButton, MoveLeftButton, ToDeckButton, MoveRightButton, CloseBoxButton };
				return _buttons;
			}
		}

		private Button[] _buttons;

		public void SetAction(CardObject card)
		{
			DiscardButton.onClick.AddListener(() => DiscardCard(card));
			MoveLeftButton.onClick.AddListener(() => MoveBoxCard(card, -1));
			MoveRightButton.onClick.AddListener(() => MoveBoxCard(card, 1));
			ToDeckButton.onClick.AddListener(() => MoveToDeck(card));
			CloseBoxButton.onClick.AddListener(() => CloseAction());
		}

		public void DiscardCard(CardObject card)
		{
			EventMoveCard.MoveCardToDeck(card.Entity);
		}

		public void MoveToDeck(CardObject card)
		{
			card.Entity.RemoveInBox();
		}

		public void MoveBoxCard(CardObject card, int direction)
		{
			card.transform.SetSiblingIndex(card.transform.GetSiblingIndex() + direction);
		}

		protected override void Show()
		{
			foreach (var btn in Buttons)
			{
				btn.gameObject.SetActive(true);
			}
		}

		protected override void Hide()
		{
			foreach (var btn in Buttons)
			{
				btn.onClick.RemoveAllListeners();
				btn.gameObject.SetActive(false);
			}
		}
	}

}
