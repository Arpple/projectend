using NUnit.Framework;
using Game;
using Entitas.Unity;

namespace Test.System
{
	public class TestTileViewLoadingSystem : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new TileViewLoadingSystem(_contexts, TestHelper.GetGameSetting().MapSetting.TileSetting));
		}

		[Test]
		public void LoadTileView()
		{
			var tile = _contexts.tile.CreateEntity();
			tile.AddGameTile(Tile.Grass);
			tile.AddGameMapPosition(1, 1);

			_systems.Initialize();

			Assert.IsTrue(tile.hasGameView);

			var view = tile.gameView.GameObject;

			Assert.IsNotNull(view);
			Assert.AreEqual(view.GetEntityLink().entity, tile);
			Assert.AreEqual("Tile (1,1)", view.name);
		}

		[TearDown]
		public void Teardown()
		{
			_systems.TearDown();
		}
	}
}
