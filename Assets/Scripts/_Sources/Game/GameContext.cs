using System.Linq;
using Entitas;
using UnityEngine.Assertions;
using UnityEngine;

public sealed partial class GameContext : Context<GameEntity>
{
	private CacheList<GameEntity, GameEntity> __cachedPlayerCharacterEntity;
	private CacheList<GameEntity, GameEntity> _cachedPlayerCharacterEntity
	{
		get
		{
			if (__cachedPlayerCharacterEntity == null) __cachedPlayerCharacterEntity = new CacheList<GameEntity, GameEntity>();
			return __cachedPlayerCharacterEntity;
		}
	}

	private CacheList<int, GameEntity> __cachedPlayerEntity;
	private CacheList<int, GameEntity> _cachedPlayerEntity
	{
		get
		{
			if (__cachedPlayerEntity == null) __cachedPlayerEntity = new CacheList<int, GameEntity>();
			return __cachedPlayerEntity;
		}
	}

	private GameEntity _gameLocalPlayerEntity;

	public GameEntity GetPlayerEntity(int playerId)
	{
		return _cachedPlayerEntity.Get(playerId, (id) =>
			this.GetEntities(GameMatcher.GamePlayer)
				.Where(e => e.gamePlayer.PlayerId == id)
				.FirstOrDefault()
		);
	}

	public GameEntity GetPlayerEntity(Player player)
	{
		return GetPlayerEntity(player.PlayerId);
	}

	public bool IsLocalPlayerTurn
	{
		get
		{
			return gameLocalPlayerEntity == gamePlayingOrder.CurrentPlayer;
		}
	}
}
