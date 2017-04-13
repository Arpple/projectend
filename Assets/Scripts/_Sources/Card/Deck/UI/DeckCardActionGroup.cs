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
		EventMoveCard.MoveCardInToBox(card.Entity);
		CloseAction();
	}

	protected override void SetActionForCard(CardObject card)
	{
		BoxButton.onClick.AddListener(() => MoveToBox(card));
		CancelButton.onClick.AddListener(CloseAction);
	}

	public override void OnCardClick(CardObject card)
	{
		base.OnCardClick(card);
		ShowCardTarget(card);
	}
}