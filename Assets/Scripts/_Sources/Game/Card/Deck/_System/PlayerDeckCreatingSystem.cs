using System.Collections.Generic;
using Entitas;
using Game.UI;
using System;

namespace Game
{
	public class PlayerDeckCreatingSystem : IInitializeSystem
	{
		private readonly GameContext _context;
		private readonly PlayerDeckFactory _cardDecks;

		public PlayerDeckCreatingSystem(Contexts contexts, PlayerDeckFactory decks)
		{
			_context = contexts.game;
			_cardDecks = decks;
		}

		public void Initialize()
		{
			foreach (var player in _context.GetEntities(GameMatcher.GamePlayer))
			{
				var playerDeck = _cardDecks.CreateContainer(player.gamePlayer.PlayerId);
				player.AddGamePlayerDeck(playerDeck);
			}
		}
	}

}
