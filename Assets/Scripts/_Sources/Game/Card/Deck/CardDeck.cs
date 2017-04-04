using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[Serializable]
	public class CardDeck
	{
		[Serializable]
		public class CardDeckCount
		{
			public Card Type;
			public int Count;
		}

		public List<CardDeckCount> SettingList;

		public CardDeck()
		{
			SettingList = new List<CardDeckCount>();
		}
	}

}
