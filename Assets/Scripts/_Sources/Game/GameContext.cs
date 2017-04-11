using System.Linq;
using Entitas;

public sealed partial class GameContext : Context<GameEntity>
{
	private CacheList<int, GameEntity> __cachedPlayerEntity;
	private CacheList<int, GameEntity> _cachedPlayerEntity
	{
		get
		{
			if (__cachedPlayerEntity == null) __cachedPlayerEntity = new CacheList<int, GameEntity>();
			return __cachedPlayerEntity;
		}
	}

	public GameEntity GetPlayerEntity(int playerId)
	{
		return _cachedPlayerEntity.Get(playerId, (id) =>
			this.GetEntities(GameMatcher.Player)
				.Where(e => e.player.PlayerId == id)
				.FirstOrDefault()
		);
	}

	public bool IsLocalPlayerTurn
	{
		get
		{
			return localEntity.isPlaying;
		}
	}
}
