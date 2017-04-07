using System.Collections.Generic;
using Entitas;
using System.Linq;
using UnityEngine;
using System;

namespace Game
{
	public class PlayingOrderSetupSystem : IInitializeSystem
	{
		readonly GameContext _context;

		public PlayingOrderSetupSystem(Contexts contexts)
		{
			Debug.Log("create order");
			_context = contexts.game;
		}

		public void Initialize()
		{
			var players = _context.GetEntities(GameMatcher.GamePlayer);

			_context.SetGamePlayingOrder(players.OrderBy(p => p.gamePlayer.PlayerId).ToList());
		}
	}
}
