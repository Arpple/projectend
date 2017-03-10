using Entitas;
using System.Collections.Generic;

namespace End
{
	public class InitializePlayerSystem : IInitializeSystem
	{
		readonly GameContext _context;
		readonly List<Player> _players;

		public InitializePlayerSystem(Contexts contexts, List<Player> players)
		{
			_context = contexts.game;
			_players = players;
		}

		public void Initialize()
		{
			foreach (var p in _players)
			{
				_context.CreateEntity()
					.AddPlayer(p);
			}
		}
	}

}
