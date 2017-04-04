using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	[Serializable]
	public class BoxCardActionGroup : CardActionGroup
	{
		public Button DiscardButton;
		public Button MoveLeftButton;
		public Button ToDeckButton;
		public Button CloseBoxButton;

		public Button[] Buttons
		{
			get
			{
				if (_buttons == null)
					_buttons = new Button[] {DiscardButton, MoveLeftButton, ToDeckButton, CloseBoxButton };
				return _buttons;
			}
		}

		private Button[] _buttons;

		public override void SetAction(CardObject card)
		{
			DiscardButton.onClick.AddListener(() => DiscardCard(card));
			MoveLeftButton.onClick.AddListener(() => MoveBoxCard(card, -1));
			ToDeckButton.onClick.AddListener(() => MoveToDeck(card));
			CloseBoxButton.onClick.AddListener(() => CloseAction());
		}

		public void DiscardCard(CardObject card)
		{
			EventMoveCard.MoveCardToShareDeck(card.Entity);
			CloseAction();
		}

		public void MoveToDeck(CardObject card)
		{
			EventMoveCard.MoveCardOutFromBox(card.Entity);
			CloseAction();
		}

		public void MoveBoxCard(CardObject card, int direction)
		{
			if(IsAtLeftMost(card))
			{
				card.transform.SetAsLastSibling();
			}
			else
			{
				card.transform.SetSiblingIndex(card.transform.GetSiblingIndex() + direction);
			}
		}

		private bool IsAtLeftMost(CardObject card)
		{
			return card.transform.GetSiblingIndex() == 0;
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
