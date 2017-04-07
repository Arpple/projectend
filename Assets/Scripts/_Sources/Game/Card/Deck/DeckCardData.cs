using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[Serializable]
	public class DeckCardData
	{
		[Serializable]
		public class CardDeckCount
		{
			public Card Type;
			public int Count;
		}

		public List<CardDeckCount> SettingList;

		public DeckCardData()
		{
			SettingList = new List<CardDeckCount>();
		}
	}

}
