using System;

[Serializable]
public class DeckSetting : IndexDataList<DeckCard, DeckCardData>
{
	public int StartCardCount;
	public int StartTurnDrawCount;
	public DeckData Deck;
}