using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Game.UI;

namespace Game
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
			foreach(var player in _context.GetEntities(GameMatcher.GamePlayer))
			{
				var playerbox = _boxContainer.CreateContainer(player.gamePlayer.PlayerId);
				player.AddGamePlayerBox(playerbox);

				if (player.isGameLocal)
				{
					playerbox.gameObject.SetActive(true);
				}
			}
		}
	}

}
