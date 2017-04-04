using System.Collections.Generic;
using Entitas;
using Game.UI;
using System;

namespace Game
{
	public class CreatePlayerDeckSystem : IInitializeSystem
	{
		private readonly GameContext _context;
		private readonly PlayerDeckFactory _cardDecks;

		public CreatePlayerDeckSystem(Contexts contexts, PlayerDeckFactory decks)
		{
			_context = contexts.game;
			_cardDecks = decks;
		}

		public void Initialize()
		{
			foreach (var player in _context.GetEntities(GameMatcher.Player))
			{
				var playerDeck = _cardDecks.CreateContainer(player.player.PlayerId);
				player.AddPlayerDeck(playerDeck);

				if(player.isLocalPlayer)
				{
					playerDeck.gameObject.SetActive(true);
				}
			}
		}
	}

}
