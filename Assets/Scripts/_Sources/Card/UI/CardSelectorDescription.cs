using System;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectorDescription : MonoBehaviour
{
	public Text DescriptionText;

	private string _mainDescription;
	private int _selectedCard;
	private int _targetCount;

	public void ShowDescription(string description, int targetCount)
	{
		_mainDescription = description;
		_selectedCard = 0;
		_targetCount = targetCount;
		gameObject.SetActive(true);
		UpdateDescription();
	}

	public void Hide()
	{
		DescriptionText.text = "";
		gameObject.SetActive(false);
	}

	public void AddSelectedCard()
	{
		_selectedCard += 1;
		UpdateDescription();
	}

	public void RemoveSelectedCard()
	{
		_selectedCard -= 1;
		UpdateDescription();
	}

	private void UpdateDescription()
	{
		DescriptionText.text = string.Format("{0}{1}{2}",
			_mainDescription,
			Environment.NewLine,
			string.Format("[{0}/{1}]", _selectedCard, _targetCount)
		);
	}


}