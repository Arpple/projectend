using Network;
using UnityEngine;
using UnityEngine.UI;

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

		public static GameEntity CreatePlayerEntity(this GameContext context, int playerId)
		{
			var e = context.CreateEntity();
			var p = new GameObject().AddComponent<Player>();
			p.PlayerId = (short)playerId;
			e.AddPlayer(p);
			e.AddId(playerId);
			return e;
		}

		public static WeatherStatusPanel CreateWeatherPanel()
		{
			var panel = new GameObject().AddComponent<WeatherStatusPanel>();
			panel.Awake();
			panel.CostObjectParent = panel.transform;
			panel.CostObjectPrefabs = CreateCostObject();
			panel.WeatherNameText = new GameObject().AddComponent<Text>();
			return panel;
		}

		public static CardObject CreateCardObject()
		{
			var obj = new GameObject().AddComponent<CardObject>();
			obj.CardNameText = new GameObject().AddComponent<Text>();
			obj.CardChargeText = new GameObject().AddComponent<Text>();
			return obj;
		}

		private static WeatherCostObject CreateCostObject()
		{
			var obj = new GameObject().AddComponent<WeatherCostObject>();
			obj.CostImage = new GameObject().AddComponent<Image>();
			obj.CostCountText = new GameObject().AddComponent<Text>();
			return obj;
		}

		public static SystemController CreateSystemController()
		{
			return new GameObject().AddComponent<SystemController>();
		}
	}
}