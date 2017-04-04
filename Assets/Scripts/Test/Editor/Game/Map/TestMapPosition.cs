using Entitas;
using NUnit.Framework;
using UnityEngine;

namespace Test
{
	public class TestMapPosition
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

			e.AddGameMapPosition(1, 1);
			var worldPos = e.gameMapPosition.GetWorldPosition();

			Assert.AreEqual(new Vector3(1, 1, 1), worldPos);
		}

		[Test]
		public void GetDistance()
		{
			var e1 = _contexts.game.CreateEntity();
			e1.AddGameMapPosition(1, 1);

			var e2 = _contexts.game.CreateEntity();
			e2.AddGameMapPosition(-2, 2);

			Assert.AreEqual(4, e1.gameMapPosition.GetDistance(e2.gameMapPosition));
		}

		[Test]
		public void Equal()
		{
			var e1 = _contexts.game.CreateEntity();
			var e2 = _contexts.game.CreateEntity();
			var e3 = _contexts.game.CreateEntity();

			e1.AddGameMapPosition(1, 1);
			e2.AddGameMapPosition(1, 1);
			e3.AddGameMapPosition(1, 2);

			Assert.IsTrue(e1.gameMapPosition.Equals(e2.gameMapPosition));
			Assert.IsFalse(e1.gameMapPosition.Equals(e3.gameMapPosition));
		}
	}	
}

