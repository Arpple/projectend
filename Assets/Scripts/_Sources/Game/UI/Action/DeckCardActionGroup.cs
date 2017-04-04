using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace End.Game.UI
{
	[Serializable]
	public class DeckCardActionGroup : ActionGroup, ICardActionGroup
	{
		public Button BoxButton;
		public Button CancelButton;

		public Button[] Buttons
		{
			get
			{
				if (_buttons == null)
					_buttons = new Button[] { BoxButton, CancelButton };
				return _buttons;
			}
		}

		private Button[] _buttons;

		public void SetAction(CardObject card)
		{
			//ActiveButton.onClick.AddListener(() => ActivateCard(card));
			BoxButton.onClick.AddListener(() => MoveToBox(card));
			CancelButton.onClick.AddListener(() => CloseAction());
			ActivateCard(card);
		}

		public void ActivateCard(CardObject card)
		{
			if (!Contexts.sharedInstance.game.IsLocalPlayerTurn) return;

			var cardEntity = card.Entity;

			if (cardEntity.hasAbility)
			{
				var ability = cardEntity.ability.Ability;
				var caster = Contexts.sharedInstance.game.LocalPlayerCharacter;

				TileTargetSelector tileSelector = new TileTargetSelector(
					caster,
					ability.GetTilesArea(caster),
					ability.GetTargetEntity,
					(t) => 
					{
						if (t.hasUnit)
						{
							EventUseCardOnUnit.Create(caster, cardEntity, t);
						}
						else if(t.hasTile)
						{
							EventUseCardOnTile.Create(caster, cardEntity, t);
						}
						CloseAction();
					}
				);

				OnCloseHandler += tileSelector.ClearSelection;
			}
		}

		public void MoveToBox(CardObject card)
		{
			EventMoveCard.MoveCardInToBox(card.Entity);
			CloseAction();
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
