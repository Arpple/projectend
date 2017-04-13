using NUnit.Framework;


namespace Test
{
	public class EntityIdGeneratorTest : ContextsTest
	{
		[Test]
		public void CreateEntity_GameContext_NoIdAdded()
		{
			var e1 = _contexts.game.CreateEntity();

			Assert.IsFalse(e1.hasId);
		}

		[Test]
		public void GenerateTileContextId()
		{
			var e1 = _contexts.tile.CreateEntity();
			var e2 = _contexts.tile.CreateEntity();

			Assert.AreEqual(0, e1.id.Id);
			Assert.AreEqual(1, e2.id.Id);
		}

		[Test]
		public void CreateEntity_MultipleContext_IdIsSeperate()
		{
			var e1 = _contexts.unit.CreateEntity();
			var e2 = _contexts.tile.CreateEntity();

			Assert.AreEqual(0, e1.id.Id);
			Assert.AreEqual(0, e2.id.Id);
		}
	}
}
