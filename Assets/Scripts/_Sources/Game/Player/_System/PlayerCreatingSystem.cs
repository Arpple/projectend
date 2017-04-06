using Entitas;
using System.Collections.Generic;

namespace Game
{
	public class PlayerCreatingSystem : IInitializeSystem
	{
		readonly GameContext _context;
		readonly List<Player> _players;

		public PlayerCreatingSystem(Contexts contexts, List<Player> players)
		{
			_context = contexts.game;
			_players = players;
		}

		public void Initialize()
		{
			foreach(var p in _players)
			{
				var playerEntity = _context.CreateEntity();
				playerEntity.AddGamePlayer(p);
			}
		}
	}

}
