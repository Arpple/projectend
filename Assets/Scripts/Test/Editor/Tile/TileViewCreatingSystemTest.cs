using Entitas.Unity;
using NUnit.Framework;

namespace Test.TileTest
{
	public class TileViewCreatingSystemTest : EntityViewCreatingSystemTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new TileViewCreatingSystem(_contexts, TestHelper.GetGameSetting().TileSetting, new UnityEngine.GameObject()));
		}

		[Test]
		public void LoadTileView()
		{
			var tile = _contexts.tile.CreateEntity();
			tile.AddSprite(null);
			tile.AddTile(Tile.Grass);
			tile.AddMapPosition(1, 1);

			_systems.Execute();

			Assert.IsTrue(tile.hasView);

			var view = tile.view.GameObject;

			Assert.IsNotNull(view);
			Assert.AreEqual(view.GetEntityLink().entity, tile);
			Assert.AreEqual("Tile (1,1)", view.name);
		}
	}
}
