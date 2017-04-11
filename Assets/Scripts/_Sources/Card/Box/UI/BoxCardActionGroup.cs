using System;
using UnityEngine.UI;

[Serializable]
public class BoxCardActionGroup : ActiveCardActionGroup
{
	public Button DiscardButton;
	public Button MoveLeftButton;
	public Button ToDeckButton;
	public Button CloseBoxButton;

	private Button[] _buttons;
	public override Button[] Buttons
	{
		get
		{
			if (_buttons == null)
				_buttons = new Button[] { DiscardButton, MoveLeftButton, ToDeckButton, CloseBoxButton };
			return _buttons;
		}
	}

	protected override void SetActionForCard(CardObject card)
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
		if (IsAtLeftMost(card))
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


}