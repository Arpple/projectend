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
			new Game.EntityIdGenerator(_contexts);
			_contexts.InitializeEntityIndices();
		}

		[TearDown]
		public void TeardownContexts()
		{
			foreach(var c in _contexts.allContexts)
			{
				c.ClearGroups();
				c.DeactivateAndRemoveEntityIndices();
			}
			_systems.ClearReactiveSystems();
			_contexts.Reset();
		}
	}
}
