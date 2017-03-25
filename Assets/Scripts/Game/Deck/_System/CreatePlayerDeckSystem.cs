using System.Collections.Generic;
using Entitas;
using End.Game.UI;
using System;

namespace End.Game
{
	public class CreatePlayerDeckSystem : IInitializeSystem
	{
		private readonly GameContext _context;
		private readonly CardContainer _cardContainerUI;

		public CreatePlayerDeckSystem(Contexts contexts, CardContainer container)
		{
			_context = contexts.game;
			_cardContainerUI = container;
		}

		public void Initialize()
		{
			foreach (var e in _context.GetEntities(GameMatcher.Player))
			{
				var playerDeck = _cardContainerUI.CreateContainer(e.player.PlayerId);
				e.AddPlayerDeck(playerDeck);
			}
		}
	}

}
