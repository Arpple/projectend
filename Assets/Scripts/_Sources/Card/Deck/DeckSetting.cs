using System;
using Entitas.Blueprints;

[Serializable]
public class DeckSetting
{
	const string BLUEPRINT_ENUM_PREFIX = "Card_";
	public int StartCardCount;
	public int StartTurnDrawCount;
	public DeckCardData Deck;

	public Blueprint GetCardBlueprint(Card card)
	{
		return null;
		//return CardBlueprints.GetBlueprint(BLUEPRINT_ENUM_PREFIX + card.ToString());
	}
}