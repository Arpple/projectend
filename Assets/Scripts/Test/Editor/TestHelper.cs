using Entitas;

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
	}
}