using Entitas;
using System.Collections.Generic;
using UnityEngine.Assertions;
using System.Linq;
using System;

namespace End.Game
{
	public class CreatePlayerCharacterSystem : IInitializeSystem
	{
		readonly GameContext _context;

		public CreatePlayerCharacterSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			var spawnpoints = _context.GetEntities(GameMatcher.Spawnpoint);
			var players = _context.GetEntities(GameMatcher.Player);
			Assert.IsTrue(spawnpoints.Length >= players.Length);

			int indexSpawnPoint = 0;
			int id = 0;
			foreach (var playerEntity in players.OrderBy(p => p.player.PlayerId))
			{
				var sp = spawnpoints[indexSpawnPoint];
				indexSpawnPoint++;

				var characterType = (Character)playerEntity.player.PlayerObject.SelectedCharacterId;
				Assert.IsTrue(characterType != Character.None);

				var character = _context.CreateEntity();
				character.AddUnit(id, playerEntity);
				character.AddCharacter(characterType);
				character.AddMapPosition(sp.mapPosition.x, sp.mapPosition.y);
				id++;
			}
		}
	}
}
