using System;
using Entitas.Blueprints;
using Entitas.Blueprints.Unity;

namespace Game
{
	[Serializable]
	public class DeckSetting
	{
		const string BLUEPRINT_ENUM_PREFIX = "Card_";
		public int StartCardCount;
		public int StartTurnDrawCount;
		public JsonBlueprints CardBlueprints;
		public DeckCardData Deck;

		public Blueprint GetCardBlueprint(Card card)
		{
			return CardBlueprints.GetBlueprint(BLUEPRINT_ENUM_PREFIX + card.ToString());
		}
	}

}
