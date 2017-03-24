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
			short id = 1;
			foreach (var cardSet in cardSetList)
			{
				cardSet.Count.Loop(() =>
				{
					var e = _context.CreateEntity();
					e.AddCard(id, cardSet.Type);
					id++;
				});
			}
		}
	}

}
