using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Game;

namespace Test
{
	public class TestEntityIdGenerator : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			new EntityIdGenerator(_contexts);
		}

		[Test]
		public void GenerateGameContextId()
		{
			var e1 = _contexts.game.CreateEntity();
			var e2 = _contexts.game.CreateEntity();

			Assert.AreEqual(0, e1.gameId.Id);
			Assert.AreEqual(1, e2.gameId.Id);
		}

		[Test]
		public void GenerateTileContextId()
		{
			var e1 = _contexts.tile.CreateEntity();
			var e2 = _contexts.tile.CreateEntity();

			Assert.AreEqual(0, e1.gameId.Id);
			Assert.AreEqual(1, e2.gameId.Id);
		}

		[Test]
		public void GenerateMixedContextId()
		{
			var e1 = _contexts.game.CreateEntity();
			var e2 = _contexts.tile.CreateEntity();

			Assert.AreEqual(0, e1.gameId.Id);
			Assert.AreEqual(0, e2.gameId.Id);
		}
	}
}
