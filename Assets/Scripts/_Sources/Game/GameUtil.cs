using System.Linq;
using Entitas;

namespace End.Game
{
	/// <summary>
	/// Utility command/shortcut class
	/// </summary>
	public static class GameUtil
	{
		public static bool IsLocalPlayerTurn
		{
			get { return GameEntity.LocalPlayer.player.PlayerId == GameEntity.Context.playingOrder.CurrentPlayerId; }
		}

		public static GameEntity LocalPlayerEntity;
		public static GameEntity LocalPlayerCharacter;

		private static CacheList<int, GameEntity> _cachedPlayerCharacter;

		public static CacheList<int, GameEntity> CachedPlayerCharacter
		{
			get
			{
				if (_cachedPlayerCharacter == null)
					_cachedPlayerCharacter = new CacheList<int, GameEntity>();
				return _cachedPlayerCharacter;
			}
		}

		public static GameEntity GetPlayerCharacter(int playerId)
		{
			return _cachedPlayerCharacter.Get(playerId, (e) =>
				GameEntity.Context.GetEntities(GameMatcher.Character)
					.Where(c => c.unit.OwnerPlayer.PlayerId == playerId)
					.FirstOrDefault()
			);
		}

		public static GameEntity GetPlayerCharacter(Player player)
		{
			return GetPlayerCharacter(player.PlayerId);
		}
	}

}
