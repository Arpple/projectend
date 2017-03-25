using System.Collections.Generic;
using Entitas;
using System.Linq;
using UnityEngine;

namespace End.Game
{
	public class PlayingOrderSystem : IInitializeSystem
	{
		readonly GameContext _context;

		private List<Player> _players;

		public PlayingOrderSystem(Contexts contexts, List<Player> players)
		{
			_context = contexts.game;
			_players = players;
		}

		public void Initialize()
		{
			_context.SetPlayingOrder(_players.Select(p => p.PlayerId).OrderBy(i => i).ToList());
			_context.playingOrder.Initialize();
			Debug.Log(_context.playingOrder);
		}
	}

}
