using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace End.Game.UI
{
	[Serializable]
	public class DeckCardActionGroup : ActionGroup, ICardActionGroup
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

		public void SetAction(CardObject card)
		{
			ActiveButton.onClick.AddListener(() => ActivateCard(card));
			BoxButton.onClick.AddListener(() => Debug.Log("Move to box " + card));
			CancelButton.onClick.AddListener(() => CloseAction());
		}

		public void ActivateCard(CardObject card)
		{
			if (!GameUtil.IsLocalPlayerTurn) return;
			GameUI.Instance.HideCardDescription();

			if (card.Entity.hasAbility)
			{
				card.Entity.ability.Ability.ActivateAbility(GameUtil.LocalPlayerCharacter,
					() =>
					{
						EventMoveCard.MoveCardToDeck(card.Entity);
						CloseAction();
					}
				);
			}
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
