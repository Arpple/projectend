using NUnit.Framework;
using UnityEngine;


namespace Test.GameTest
{
	public class TestViewContainerSystem : ContextsTest
	{
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
