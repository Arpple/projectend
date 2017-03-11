using NUnit.Framework;
using UnityEngine;

namespace End.Test
{
	public class RenderMapPositionSystem
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

		[Test]
		public void RenderPosition()
		{
			//given
			var system = new Game.RenderMapPositionSystem(_contexts);

			var entity = _contexts.game.CreateEntity();
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