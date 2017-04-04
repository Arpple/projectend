using UnityEngine;

namespace Test
{
	public static class TestHelper
	{
		public static Contexts CreateContexts()
		{
			var _contexts = Contexts.sharedInstance;
			_contexts.SetAllContexts();

			return _contexts;
		}

		public static Game.GameSetting GetGameSetting()
		{
			return Object.Instantiate<Game.GameSetting>(Resources.Load<Game.GameSetting>("Game/_Setting/GameSetting"));
		}

		public static GameEntity CreatePlayerEntity(this GameContext context, int playerId)
		{
			var e = context.CreateEntity();
			var p = new GameObject().AddComponent<Player>();
			p.PlayerId = (short)playerId;

			e.AddPlayer(p);
			return e;
		}
	}
}