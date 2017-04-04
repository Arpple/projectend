using NUnit.Framework;
using UnityEngine;
using Game;

namespace Test.System
{
	public class TestRenderMapPositionSystem : ContextsTest
	{
		[Test]
		public void RenderPosition()
		{
			//given
			var system = new RenderMapPositionSystem(_contexts);

			var entity = _contexts.game.CreateEntity();
			entity.AddGameView(new GameObject());
			entity.AddGameMapPosition(1, 1);

			//action
			system.Execute();
			var transform = entity.gameView.GameObject.transform;
			var worldPosition = transform.position;

			//then
			Assert.AreEqual(worldPosition, entity.gameMapPosition.GetWorldPosition());

			//update
			entity.ReplaceGameMapPosition(1, 2);
			system.Execute();

			Assert.AreNotEqual(worldPosition, transform.position);
		}
	}
}