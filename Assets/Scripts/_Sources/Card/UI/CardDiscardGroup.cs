using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class CardDiscardGroup : CardActionGroup
{
	public Button ConfirmButton;
	public Button CancelButton;

	private List<CardObject> _discardingCards;
	private UnityAction _onCardsDiscarded;
	private int _targetCount;
	private GameObject _previousCardPanel;

	private Button[] _buttons;
	public override Button[] Buttons
	{
		get
		{
			if (_buttons == null)
				_buttons = new[] { ConfirmButton, CancelButton };
			return _buttons;
		}
	}

	public CardDiscardGroup()
	{
		_discardingCards = new List<CardObject>();
	}

	protected override void Show()
	{
		base.Show();
		ConfirmButton.onClick.AddListener(DiscardAndDoAction);
		CancelButton.onClick.AddListener(Cancel);
		CardPanel.SetActive(true);
	}

	public void Setup(GameObject previousCardPanel, int discardCount, UnityAction onCardsDiscarded)
	{
		_targetCount = discardCount;
		_onCardsDiscarded = onCardsDiscarded;
		_previousCardPanel = previousCardPanel;
		if (_previousCardPanel != null && _previousCardPanel != CardPanel)
			_previousCardPanel.SetActive(false);
	}

	protected override void Hide()
	{
		base.Hide();
		_discardingCards.Clear();
		CardPanel.SetActive(false);
		if(_previousCardPanel != null)
			_previousCardPanel.SetActive(true);
	}

	public override void OnCardClick(CardObject card)
	{
		if (_discardingCards.Contains(card))
		{
			RemoveFromDiscardList(card);
		}
		else
		{
			AddToDiscardList(card);
		}
	}

	private void RemoveFromDiscardList(CardObject card)
	{
		_discardingCards.Remove(card);
		card.HideHighlight();
	}

	private void AddToDiscardList(CardObject card)
	{
		if (!IsTargetCountReached())
		{
			_discardingCards.Add(card);
			card.ShowHighlight();
		}
	}

	private void DiscardAndDoAction()
	{
		if (!IsTargetCountReached()) return;

		DiscardCards();
		CloseAction();
		_onCardsDiscarded();
	}

	private void DiscardCards()
	{
		foreach (var card in _discardingCards)
		{
			card.HideHighlight();
			EventMoveDeckCard.MoveCardToShareDeck(card.Entity);
		}
	}

	private bool IsTargetCountReached()
	{
		return _targetCount == _discardingCards.Count;
	}

	private void Cancel()
	{
		foreach(var card in _discardingCards)
		{
			card.HideHighlight();
		}
		_discardingCards.Clear();
		CloseAction();
	}
}