using NUnit.Framework;
using UnityEngine;


namespace Test.TileTest
{
	public class TilePositionRenderingSystemTest : ContextsTest
	{
		[Test]
		public void RenderPosition()
		{
			//given
			var system = new TilePositionRenderingSystem(_contexts);

			var entity = _contexts.tile.CreateEntity();
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