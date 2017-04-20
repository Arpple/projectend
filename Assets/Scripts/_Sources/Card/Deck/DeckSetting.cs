using System;

[Serializable]
public class DeckSetting : IndexDataList<DeckCard, DeckCardData>
{
	public int MaxHandCardCount;
	public int StartCardCount;
	public int StartTurnDrawCount;
	public DeckData Deck;
}