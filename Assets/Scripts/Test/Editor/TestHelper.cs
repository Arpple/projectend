using UnityEngine;

namespace End.Test
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
			return Object.Instantiate<Game.GameSetting>(Resources.Load<Game.GameSetting>("Game/Core/_Setting/GameSetting"));
		}
	}
}