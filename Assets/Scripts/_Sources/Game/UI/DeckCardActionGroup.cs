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
				var ability = card.Entity.ability.Ability;

				if(ability is ITargetAbility)
				{
					var cancel = (CancelActionGroup)ShowSubAction(GameUI.Instance.CancelGroup);

					var targetAbility = (ITargetAbility)ability;
					TileTargetSelector tileSelector = new TileTargetSelector(
						targetAbility.GetTilesArea(GameUtil.LocalPlayerCharacter),
						targetAbility.GetTargetEntity,
						(t) => 
						{
							targetAbility.OnTargetSelected(t);
							cancel.CloseAction();
							EventMoveCard.MoveCardToDeck(card.Entity);
							CloseAction();
						}
					);

					cancel.SetAction(() => tileSelector.ClearSelection());
				}
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
