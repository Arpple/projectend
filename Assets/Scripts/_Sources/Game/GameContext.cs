using System.Linq;
using Entitas;
using UnityEngine.Assertions;

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

	private GameEntity _localPlayerEntity;
	private GameEntity _localPlayerCharacter;

	public bool IsLocalPlayerTurn
	{
		get { return GameEntity.LocalPlayer.player.PlayerId == GameEntity.Context.playingOrder.CurrentPlayerId; }
	}

	public GameEntity LocalPlayerCharacter
	{
		get
		{
			return this.GetEntities(GameMatcher.Character)
				.Where(c => c.unit.OwnerEntity.isLocalPlayer)
				.FirstOrDefault();
		}
	}

	public GameEntity GetCharacterFromPlayer(GameEntity playerEntity)
	{
		return _cachedPlayerCharacterEntity.Get(playerEntity, (id) =>
			this.GetEntities(GameMatcher.Character)
				.Where(c => c.unit.OwnerEntity == playerEntity)
				.FirstOrDefault()
		);
	}

	public GameEntity GetPlayerEntity(int playerId)
	{
		return _cachedPlayerEntity.Get(playerId, (id) =>
			GameEntity.Context.GetEntities(GameMatcher.Player)
				.Where(e => e.player.PlayerId == id)
				.FirstOrDefault()
		);
	}

	public GameEntity GetPlayerEntity(End.Player player)
	{
		return GetPlayerEntity(player.PlayerId);
	}
}
