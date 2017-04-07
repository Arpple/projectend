using UnityEngine;
using Entitas;
using System;

namespace Game
{
	/// <summary>
	/// System for creating card entity from deck
	/// </summary>
	/// <seealso cref="Entitas.IInitializeSystem" />
	public class DeckCardCreatingSystem : IInitializeSystem
	{
		readonly CardContext _context;
		readonly DeckCardData _deck;

		public DeckCardCreatingSystem(Contexts contexts, DeckCardData deck)
		{
			_context = contexts.card;
			_deck = deck;
		}

		public void Initialize()
		{
			var cardSetList = _deck.SettingList;
			foreach (var cardSet in cardSetList)
			{
				cardSet.Count.Loop(() =>
				{
					var e = _context.CreateCard(cardSet.Type);
					e.isGameDeckCard = true;
				});
			}
		}
	}

}
