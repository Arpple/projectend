using System;
using UnityEngine.UI;

[Serializable]
public class DeckCardActionGroup : ActiveCardActionGroup
{
	public Button BoxButton;
	public Button CancelButton;

	private Button[] _buttons;
	public override Button[] Buttons
	{
		get
		{
			if (_buttons == null)
				_buttons = new Button[] { BoxButton, CancelButton };
			return _buttons;
		}
	}

	public void MoveToBox(CardObject card)
	{
		if (!Contexts.sharedInstance.game.IsLocalPlayerTurn) return;

		EventMoveDeckCard.MoveCardInToBox(card.Entity);
		CloseAction();
	}

	protected override void SetActionForCard(CardObject card)
	{
		BoxButton.onClick.AddListener(() => MoveToBox(card));
		CancelButton.onClick.AddListener(CloseAction);
		if (IsActiveCard(card))
			ShowCardTarget(card);
	}

	private bool IsActiveCard(CardObject card)
	{
		return card.Entity.hasAbility && card.Entity.ability.Ability is IActiveAbility;
	}
}