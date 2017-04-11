using UI;
using UnityEngine;

public abstract class CardActionGroup : ActionGroup
{
	public GameObject CardPanel;

	public abstract void OnCardClick(CardObject card);
}