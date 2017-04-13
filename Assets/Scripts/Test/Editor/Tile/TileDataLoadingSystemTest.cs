using NUnit.Framework;

namespace Test.TileTest
{
	public class TileDataLoadingSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new TileDataLoadingSystem(_contexts, TestHelper.GetGameSetting().TileSetting));
		}

		[Test]
		public void Execute_TileEntity_ComponentFromDataLoaded()
		{
			var tile = _contexts.tile.CreateEntity();
			tile.AddTile(Tile.Grass);

			_systems.Execute();
			Assert.IsTrue(tile.hasSprite);
		}
	}
}
