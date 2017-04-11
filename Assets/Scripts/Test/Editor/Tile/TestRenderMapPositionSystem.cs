using NUnit.Framework;
using UnityEngine;


namespace Test.TileTest
{
	public class TestPositionRenderingSystem : ContextsTest
	{
		[Test]
		public void RenderPosition()
		{
			//given
			var system = new UnitPositionRenderingSystem(_contexts);

			var entity = _contexts.unit.CreateEntity();
			entity.AddView(new GameObject());
			entity.AddMapPosition(1, 1);

			//action
			system.Execute();
			var transform = entity.view.GameObject.transform;
			var worldPosition = transform.position;

			//then
			Assert.AreEqual(worldPosition, entity.mapPosition.GetWorldPosition());

			//update
			entity.ReplaceMapPosition(1, 2);
			system.Execute();

			Assert.AreNotEqual(worldPosition, transform.position);
		}
	}
}