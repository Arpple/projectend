using UnityEngine;
using Entitas;
using System;

namespace End.Game
{
	/// <summary>
	/// System for creating card entity from deck
	/// </summary>
	/// <seealso cref="Entitas.IInitializeSystem" />
	public class CreateDeckCardsSystem : IInitializeSystem
	{
		readonly GameContext _context;
		readonly CardDeck _deck;

		public CreateDeckCardsSystem(Contexts contexts, CardDeck deck)
		{
			_context = contexts.game;
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
					e.isDeckCard = true;
				});
			}
		}
	}

}
