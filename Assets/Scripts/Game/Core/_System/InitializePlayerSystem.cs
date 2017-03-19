using Entitas;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace End.Game
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
			var spawnpoints = _context.GetEntities(GameMatcher.Spawnpoint);
			Assert.IsTrue(spawnpoints.Length >= _players.Count);

			_players.Count.Loop(
				(i) =>
				{
					var p = _players[i];
					var sp = spawnpoints[i];

					//create player
					_context.CreateEntity()
						.AddPlayer(p);

					//create character
					var character = _context.CreateEntity();
					character.AddUnit(p);
					character.AddCharacter((Character)p.SelectedCharacterId);
					character.AddMapPosition(sp.mapPosition.x, sp.mapPosition.y);
				}
			);
		}
	}

}
