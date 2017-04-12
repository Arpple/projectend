using UnityEngine;
using Network;

namespace Test
{
	public static class TestHelper
	{
		public static Contexts CreateContexts()
		{
			var _contexts = Contexts.sharedInstance;
			_contexts.game = new GameContext();
			_contexts.gameEvent = new GameEventContext();
			_contexts.card = new CardContext();
			_contexts.tile = new TileContext();
			_contexts.unit = new UnitContext();
			return _contexts;
		}

		public static Setting GetGameSetting()
		{
			return Object.Instantiate<Setting>(Resources.Load<Setting>("Game/Setting"));
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