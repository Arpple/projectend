using Entitas;
using NUnit.Framework;
using UnityEngine;

namespace End.Test
{
	public class MapPosition
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

		[Test]
		public void GetWorldPosition()
		{
			var e = _contexts.game.CreateEntity();

			e.AddMapPosition(1, 1);
			var worldPos = e.mapPosition.GetWorldPosition();

			Assert.AreEqual(new Vector3(1.65f, 1.65f, 1), worldPos);
		}

		[Test]
		public void GetDistance()
		{
			var e1 = _contexts.game.CreateEntity();
			e1.AddMapPosition(1, 1);

			var e2 = _contexts.game.CreateEntity();
			e2.AddMapPosition(-2, 2);

			Assert.AreEqual(4, e1.mapPosition.GetDistance(e2.mapPosition));
		}

		[Test]
		public void Equal()
		{
			var e1 = _contexts.game.CreateEntity();
			var e2 = _contexts.game.CreateEntity();
			var e3 = _contexts.game.CreateEntity();

			e1.AddMapPosition(1, 1);
			e2.AddMapPosition(1, 1);
			e3.AddMapPosition(1, 2);

			Assert.IsTrue(e1.mapPosition.IsEqual(e2.mapPosition));
			Assert.IsFalse(e1.mapPosition.IsEqual(e3.mapPosition));
		}
	}	
}

