﻿using System;
using Entitas.Blueprints;
using Entitas.Unity.Blueprints;

namespace Game
{
	[Serializable]
	public class DeckSetting
	{
		const string BLUEPRINT_ENUM_PREFIX = "Card_";
		public int StartCardCount;
		public JsonBlueprints CardBlueprints;
		public DeckCardData Deck;

		public Blueprint GetCardBlueprint(Card card)
		{
			return CardBlueprints.GetBlueprint(BLUEPRINT_ENUM_PREFIX + card.ToString());
		}
	}

}
