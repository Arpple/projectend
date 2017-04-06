using Entitas;
using System.Collections.Generic;
using UnityEngine.Assertions;
using System.Linq;
using System;

namespace Game
{
	public class CreatePlayerCharacterSystem : IInitializeSystem
	{
		readonly GameContext _gameContext;
		readonly TileContext _tileContext;
		readonly UnitContext _unitContext;

		public CreatePlayerCharacterSystem(Contexts contexts)
		{
			_gameContext = contexts.game;
			_tileContext = contexts.tile;
			_unitContext = contexts.unit;
		}

		public void Initialize()
		{
			var spawnpoints = _tileContext.GetEntities(TileMatcher.GameSpawnpoint);
			var players = _gameContext.GetEntities(GameMatcher.GamePlayer);
			Assert.IsTrue(spawnpoints.Length >= players.Length);

			int indexSpawnPoint = 0;
			int id = 0;
			foreach (var playerEntity in players.OrderBy(p => p.gamePlayer.PlayerId))
			{
				var sp = spawnpoints[indexSpawnPoint];
				indexSpawnPoint++;

				var characterType = (Character)playerEntity.gamePlayer.PlayerObject.SelectedCharacterId;
				Assert.IsTrue(characterType != Character.None);

				var character = _unitContext.CreateEntity();
				character.AddGameOwner(playerEntity);
				character.AddGameCharacter(characterType);
				character.AddGameMapPosition(sp.gameMapPosition.x, sp.gameMapPosition.y);
				id++;

				if(playerEntity.isGameLocalPlayer)
				{
					character.isGameLocalPlayer = true;
				}
			}
		}
	}
}
