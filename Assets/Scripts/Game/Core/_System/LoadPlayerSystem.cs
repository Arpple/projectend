using Entitas;
using System.Collections.Generic;

namespace End.Game
{
	public class LoadPlayerSystem : IInitializeSystem
	{
		readonly GameContext _context;
		readonly List<Player> _players;

		public LoadPlayerSystem(Contexts contexts, List<Player> players)
		{
			_context = contexts.game;
			_players = players;
		}

		public void Initialize()
		{
			foreach(var p in _players)
			{
				var playerEntity = _context.CreateEntity();
				playerEntity.AddPlayer(p);
			}
		}
	}

}
