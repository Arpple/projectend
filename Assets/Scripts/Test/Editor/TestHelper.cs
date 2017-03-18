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

		public static End.Game.GameSetting GetGameSetting()
		{
			return Resources.Load<End.Game.GameSetting>("Game/Core/_Setting/GameSetting");
		}
	}
}