using System.Collections.Generic;
using Entitas;
using System.Linq;
using UnityEngine;

namespace Game
{
	public class gamePlayingOrderSystem : IInitializeSystem
	{
		readonly GameContext _context;

		public gamePlayingOrderSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			var players = _context.GetEntities(GameMatcher.GamePlayer);

			_context.SetGamePlayingOrder(players.OrderBy(p => p.gamePlayer.PlayerId).ToList());
			_context.gamePlayingOrder.Initialize();
			Debug.Log(_context.gamePlayingOrder);
		}
	}

}
