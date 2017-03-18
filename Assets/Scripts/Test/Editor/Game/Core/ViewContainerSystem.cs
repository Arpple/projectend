using UnityEngine;
using NUnit.Framework;
using End.Game;

namespace End.Test
{
	public class TestViewContainerSystem
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

		[Test]
		public void EditorTest()
		{
			var system = new ViewContainerSystem(_contexts);

			var entity = _contexts.game.CreateEntity();
			entity.AddView(new GameObject());
			entity.AddViewContainer("Path/To");

			system.Execute();

			var parent1 = entity.view.GameObject.transform.parent;
			Assert.AreEqual("To", parent1.name);
			Assert.AreEqual("Path", parent1.parent.name);

		}
	}

}
