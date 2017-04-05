using NUnit.Framework;
using Entitas;

namespace Test
{
	public class ContextsTest
	{
		protected Contexts _contexts;
		protected Systems _systems;

		[SetUp]
		public void SetupContexts()
		{
			_contexts = TestHelper.CreateContexts();
			_systems = new Systems();
		}

		[TearDown]
		public void TeardownContexts()
		{
			foreach(var c in _contexts.allContexts)
			{
				c.ClearGroups();
			}
			_systems.ClearReactiveSystems();
			_contexts.Reset();
		}
	}
}
