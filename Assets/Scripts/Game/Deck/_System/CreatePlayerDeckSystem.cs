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
			foreach (var player in _context.GetEntities(GameMatcher.Player))
			{
				var playerDeck = _cardContainerUI.CreateContainer(player.player.PlayerId);
				player.AddPlayerDeck(playerDeck);

				if(player.isLocalPlayer)
				{
					playerDeck.SetActive(true);
				}
			}
		}
	}

}
