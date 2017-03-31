using System.Linq;
using Entitas;
using UnityEngine.Assertions;

namespace End.Game
{
	/// <summary>
	/// Utility command/shortcut class
	/// </summary>
	public class GameUtil
	{
		public static GameUtil Instance;

		private CacheList<int, GameEntity> _cachedPlayerCharacterEntity;
		private CacheList<int, GameEntity> _cachedPlayerEntity;
		private GameEntity _localPlayerEntity;
		private GameEntity _localPlayerCharacter;

		public GameUtil()
		{
			Instance = this;

			_cachedPlayerCharacterEntity = new CacheList<int, GameEntity>();
			_cachedPlayerEntity = new CacheList<int, GameEntity>();
			_localPlayerEntity = null;
			_localPlayerCharacter = null;
		}

		public static bool IsLocalPlayerTurn
		{
			get { return GameEntity.LocalPlayer.player.PlayerId == GameEntity.Context.playingOrder.CurrentPlayerId; }
		}

		public static GameEntity LocalPlayerEntity
		{
			get { return Instance._localPlayerEntity; }
			set { Instance._localPlayerEntity = value; }
		}

		public static GameEntity LocalPlayerCharacter
		{
			get { return Instance._localPlayerCharacter; }
			set { Instance._localPlayerCharacter = value; }
		}

		public static GameEntity GetCharacterFromPlayer(int playerId)
		{
			return Instance._cachedPlayerCharacterEntity.Get(playerId, (id) =>
				GameEntity.Context.GetEntities(GameMatcher.Character)
					.Where(c => c.unit.OwnerEntity.player.PlayerId == id)
					.FirstOrDefault()
			);
		}

		public static GameEntity GetCharacterFromPlayer(GameEntity playerEntity)
		{
			Assert.IsTrue(playerEntity.hasPlayer);

			return GetCharacterFromPlayer(playerEntity.player.PlayerId);
		}

		public static GameEntity GetPlayerEntity(int playerId)
		{
			return Instance._cachedPlayerEntity.Get(playerId, (id) =>
				GameEntity.Context.GetEntities(GameMatcher.Player)
					.Where(e => e.player.PlayerId == id)
					.FirstOrDefault()
			);
		}

		public static GameEntity GetPlayerEntity(Player player)
		{
			return GetPlayerEntity(player.PlayerId);
		}
	}

}
