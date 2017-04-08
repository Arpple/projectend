using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Game.UI
{
	public abstract class ActiveCardActionGroup : CardActionGroup
	{
		private CardObject _focusedCard;

		protected UnityAction OnStopFocusingCard;

		protected override void Show()
		{
			base.Show();
			OnCloseHandler += () => GameUI.Instance.CardDesc.gameObject.SetActive(false);
		}

		protected override void Hide()
		{
			base.Hide();
			StopFocusingCard();
		}

		public override void OnCardClick(CardObject card)
		{
			if(!IsFocusedCard(card))
			{
				if(_focusedCard != null)
				{
					StopFocusingCard();
				}
				FocusOnCard(card);
			}
			else
			{
				GameUI.Instance.CardDesc.ToggleVisibility();
			}
		}

		private void FocusOnCard(CardObject card)
		{
			_focusedCard = card;
			GameUI.Instance.CardDesc.SetDescription(card);
			GameUI.Instance.CardDesc.gameObject.SetActive(false);
			SetActionForCard(card);
		}

		protected void StopFocusingCard()
		{
			if (OnStopFocusingCard != null) OnStopFocusingCard();
			_focusedCard = null;

			foreach (var btn in Buttons)
			{
				btn.onClick.RemoveAllListeners();
			}
		}

		private bool IsFocusedCard(CardObject card)
		{
			return _focusedCard == card && card != null;
		}

		protected abstract void SetActionForCard(CardObject card);

		protected void ShowCardTarget(CardObject card)
		{
			if (!Contexts.sharedInstance.game.IsLocalPlayerTurn) return;

			var cardEntity = card.Entity;

			if (cardEntity.hasGameAbility)
			{
				var caster = Contexts.sharedInstance.unit.gameLocalEntity;
				var caller = new CardAbilityCaller(caster, cardEntity);

				if (!caller.TryUseAbility<UnitEntity>(
					(t) =>
					{
						EventUseCardOnUnit.Create(caster, cardEntity, t);
						CloseAction();
					}
				))
				if (!caller.TryUseAbility<TileEntity>(
					(t) =>
					{
						EventUseCardOnTile.Create(caster, cardEntity, t);
						CloseAction();
					}
				))
					return;

				OnStopFocusingCard += caller.CancelAction;
			}
		}
	}
}
