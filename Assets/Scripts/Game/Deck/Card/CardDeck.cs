using System;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game
{
	public class CardDeck : ScriptableObject
	{
		[Serializable]
		public class CardDeckCount
		{
			public Card Type;
			public int Count;
		}

		public List<CardDeckCount> SettingList;
	}

}
