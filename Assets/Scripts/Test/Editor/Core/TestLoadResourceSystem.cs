using Entitas;
using Entitas.Unity;
using NUnit.Framework;
using UnityEngine;

namespace End.Test
{
	public class TestLoadResourceSystem
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
			var system = new LoadResourceSystem(_contexts);

			var entity = _contexts.game.CreateEntity();
			entity.AddResource(Resources.Load<Sprite>("Ability/Card_Image/Basic/Basic_Attack"));

			//action
			system.Execute();

			//then
			Assert.IsTrue(
				entity.hasView
				&& entity.view.GameObject.GetEntityLink().entity == entity
			);
		}
	}
}

