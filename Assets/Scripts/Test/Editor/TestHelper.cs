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
			return Object.Instantiate(Resources.Load<Setting>("Setting"));
		}

		public static Title.TitleSetting GetTitleSetting()
		{
			return Object.Instantiate(Resources.Load<Title.TitleSetting>("Addition/Title/Setting"));
		}

		public static GameEntity CreatePlayerEntity(this GameContext context, int playerId)
		{
			var e = context.CreateEntity();
			var p = new GameObject().AddComponent<Player>();
			p.PlayerId = (short)playerId;
			e.AddPlayer(p);
			e.AddId(playerId);
			return e;
		}
	}
}