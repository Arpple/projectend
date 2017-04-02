using System.Collections.Generic;
using Entitas;
using System.Linq;
using UnityEngine;

namespace End.Game
{
	public class PlayingOrderSystem : IInitializeSystem
	{
		readonly GameContext _context;

		public PlayingOrderSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			var players = _context.GetEntities(GameMatcher.Player);

			_context.SetPlayingOrder(players.OrderBy(p => p.player.PlayerId).ToList());
			_context.playingOrder.Initialize();
			Debug.Log(_context.playingOrder);
		}
	}

}
