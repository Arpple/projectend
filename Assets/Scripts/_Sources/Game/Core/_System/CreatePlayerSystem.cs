using Entitas;
using System.Collections.Generic;

namespace End.Game
{
	public class CreatePlayerSystem : IInitializeSystem
	{
		readonly GameContext _context;
		readonly List<Player> _players;

		public CreatePlayerSystem(Contexts contexts, List<Player> players)
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
