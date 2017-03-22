using System;
using Entitas.Blueprints;
using Entitas.Unity.Blueprints;

namespace End.Game
{
	[Serializable]
	public class CardSetting
	{
		const string BLUEPRINT_ENUM_PREFIX = "Card_";

		public Blueprints CardBlueprints;
		public CardDeck Deck;

		public Blueprint GetCardBlueprint(Card card)
		{
			return CardBlueprints.GetBlueprint(BLUEPRINT_ENUM_PREFIX + card.ToString());
		}
	}

}
