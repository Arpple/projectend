using System.Collections.Generic;
using Entitas;
using NUnit.Framework;
using UnityEngine;

namespace Test.CardTest.DeckTest
{
	public class TestDeckCardCreatingSystem : ContextsTest
	{
		[Test]
		public void CreatedEntityCount()
		{
			var deck = new DeckSetting();
			var deckData = ScriptableObject.CreateInstance<DeckCardData>();
			deckData.Type = DeckCard.Move;
			deckData.CreateCount = 2;
			deck.DataList = new List<DeckCardData>
			{
				deckData
			};

			var system = new DeckCardCreatingSystem(_contexts, deck);
			system.Initialize();

			var cards = _contexts.card.GetEntities(CardMatcher.DeckCard);
			Assert.AreEqual(2, cards.Length);
		}
	}
}

