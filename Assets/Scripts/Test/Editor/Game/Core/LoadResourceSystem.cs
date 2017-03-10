using Entitas;
using Entitas.Unity;
using NUnit.Framework;
using UnityEngine;

namespace End.Test
{
	public class LoadResourceSystem
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

		[Test]
		public void LoadSprite()
		{
			//given
			var system = new End.LoadResourceSystem(_contexts);

			var entity = _contexts.game.CreateEntity();
			entity.AddResource("Game/Ability/CardImage/Basic/Basic_Attack");

			//action
			system.Execute();

			//then
			Assert.IsTrue(entity.hasView);
			Assert.AreEqual(entity, entity.view.GameObject.GetEntityLink().entity);
		}
	}
}

