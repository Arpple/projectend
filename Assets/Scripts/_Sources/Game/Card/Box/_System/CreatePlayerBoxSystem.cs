using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using End.Game.UI;

namespace End.Game
{
	public class CreatePlayerBoxSystem : IInitializeSystem
	{
		private GameContext _context;
		private PlayerBoxFactory _boxContainer;

		public CreatePlayerBoxSystem(Contexts contexts, PlayerBoxFactory boxContainer)
		{
			_context = contexts.game;
			_boxContainer = boxContainer;
		}

		public void Initialize()
		{
			foreach(var player in _context.GetEntities(GameMatcher.Player))
			{
				var playerbox = _boxContainer.CreateContainer(player.player.PlayerId);
				player.AddPlayerBox(playerbox);

				if (player.isLocalPlayer)
				{
					playerbox.gameObject.SetActive(true);
				}
			}
		}
	}

}
