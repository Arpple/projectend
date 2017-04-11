﻿using System.Linq;
using Entitas;

namespace Game
{
	public class LocalPlayerSetupSystem : IInitializeSystem
	{
		private readonly Player _localPlayer;
		private readonly GameContext _context;

		public LocalPlayerSetupSystem(Contexts contexts, Player localPlayer)
		{
			_localPlayer = localPlayer;
			_context = contexts.game;
		}

		public void Initialize()
		{
			var gameLocalPlayerEntity = _context.GetEntities(GameMatcher.GamePlayer).Where(p => p.gamePlayer.PlayerObject == _localPlayer)
				.First();

			gameLocalPlayerEntity.isGameLocal = true;
		}
	}
}
