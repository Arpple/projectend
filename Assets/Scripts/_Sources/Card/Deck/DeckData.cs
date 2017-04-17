using System;
using System.Collections.Generic;

[Serializable]
public class DeckData
{
	[Serializable]
	public class CardDeckCount
	{
		public DeckCard Type;
		public int Count;
	}

	public List<CardDeckCount> SettingList;

	public DeckData()
	{
		SettingList = new List<CardDeckCount>();
	}
}