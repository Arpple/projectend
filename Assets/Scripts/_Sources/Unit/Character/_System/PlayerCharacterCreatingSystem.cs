using System.Linq;
using Entitas;
using UnityEngine.Assertions;

public class PlayerCharacterCreatingSystem : IInitializeSystem
{
	readonly GameContext _gameContext;
	readonly TileContext _tileContext;
	readonly UnitContext _unitContext;

	public PlayerCharacterCreatingSystem(Contexts contexts)
	{
		_gameContext = contexts.game;
		_tileContext = contexts.tile;
		_unitContext = contexts.unit;
	}

	public void Initialize()
	{
		var spawnpoints = _tileContext.GetEntities(TileMatcher.Spawnpoint);
		var players = _gameContext.GetEntities(GameMatcher.Player);
		Assert.IsTrue(spawnpoints.Length >= players.Length);

		int i = 0;
		foreach (var playerEntity in players.OrderBy(p => p.player.PlayerId))
		{
			var sp = spawnpoints[i];

			var characterType = (Character)playerEntity.player.PlayerObject.SelectedCharacterId;
			Assert.IsTrue(characterType != Character.None);

			var character = _unitContext.CreateEntity();
			character.AddOwner(playerEntity);
			character.AddCharacter(characterType);
			character.AddMapPosition(sp.mapPosition.x, sp.mapPosition.y);
			i++;
		}
	}
}