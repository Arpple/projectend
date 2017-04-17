using NUnit.Framework;
using Entitas;
using UnityEngine;

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
			new EntityIdGenerator(_contexts);
			_contexts.InitializeEntityIndices();
		}

		[TearDown]
		public void TeardownContexts()
		{
			//_systems.ClearReactiveSystems();
			//_contexts.Reset();
		}

		protected GameEntity CreatePlayerEntity(int playerId)
		{
			return TestHelper.CreatePlayerEntity(_contexts.game, playerId);
		}

		protected SystemController CreateSystemController()
		{
			return new GameObject().AddComponent<SystemController>();
		}
	}
}
