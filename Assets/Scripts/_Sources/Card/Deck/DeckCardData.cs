using UnityEngine;

[CreateAssetMenu(menuName = "End/Card - Deck", fileName = "new_card.asset")]
public class DeckCardData : CardData
{
	[Header("DeckCard")]
	public DeckCard Type;
	[Space]
	public string AbilityClassFullName;
}