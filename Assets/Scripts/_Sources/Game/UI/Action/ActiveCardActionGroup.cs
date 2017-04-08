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

		protected override void Show()
		{
			base.Show();
		}

		protected override void Hide()
		{
			if(HasPreviousFocusCard())
				StopFocusingCard();
			base.Hide();
		}

		public override void OnCardClick(CardObject card)
		{
			if(!IsFocusedCard(card))
			{
				if(HasPreviousFocusCard())
					StopFocusingCard();

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
			card.ShowHighlight();
		}

		protected void StopFocusingCard()
		{
			_focusedCard.HideHighlight();
			_focusedCard = null;
			GameUI.Instance.CardDesc.gameObject.SetActive(false);
			ClearButtonAction();

			if (_cardCaller != null)
			{
				_cardCaller.CancelAction();
			}
		}

		private bool IsFocusedCard(CardObject card)
		{
			return _focusedCard == card && card != null;
		}

		private bool HasPreviousFocusCard()
		{
			return _focusedCard != null;
		}

		protected abstract void SetActionForCard(CardObject card);

		protected void ClearButtonAction()
		{
			foreach(var btn in Buttons)
			{
				btn.onClick.RemoveAllListeners();
			}
		}

		private CardAbilityCaller _cardCaller;

		protected void ShowCardTarget(CardObject card)
		{
			if (!Contexts.sharedInstance.game.IsLocalPlayerTurn) return;

			var cardEntity = card.Entity;

			if (cardEntity.hasGameAbility)
			{
				var caster = Contexts.sharedInstance.unit.gameLocalEntity;
				_cardCaller = new CardAbilityCaller(this, caster, cardEntity);

				if (!_cardCaller.TryUseAbility<UnitEntity>(
					(t) =>
					{
						EventUseCardOnUnit.Create(caster, cardEntity, t);
					}
				))
				if (!_cardCaller.TryUseAbility<TileEntity>(
					(t) =>
					{
						EventUseCardOnTile.Create(caster, cardEntity, t);
					}
				))
					return;
			}
		}
	}
}
