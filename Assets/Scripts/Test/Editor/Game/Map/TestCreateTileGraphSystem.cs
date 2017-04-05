using System.Linq;
using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestCreateTileGraphSystem : ContextsTest
	{
		[Test]
		public void GetConnectedTiles()
		{
			var originTile = CreateTile(2, 2);
			var leftTile = CreateTile(1, 2);
			var rightTile = CreateTile(3, 2);
			var upTile = CreateTile(2, 3);
			var downTile = CreateTile(2, 1);
			var unconnectedTile = CreateTile(1, 1);

			var system = new CreateTileGraphSystem(_contexts);
			system.Initialize();

			Assert.AreEqual(leftTile, originTile.gameTileGraph.Left);
			Assert.AreEqual(rightTile, originTile.gameTileGraph.Right);
			Assert.AreEqual(upTile, originTile.gameTileGraph.Up);
			Assert.AreEqual(downTile, originTile.gameTileGraph.Down);

			var connectedTiles = originTile.gameTileGraph.GetConnectedTiles();

			Assert.IsTrue(connectedTiles.Contains(leftTile));
			Assert.IsTrue(connectedTiles.Contains(rightTile));
			Assert.IsTrue(connectedTiles.Contains(upTile));
			Assert.IsTrue(connectedTiles.Contains(downTile));
			Assert.IsFalse(connectedTiles.Contains(unconnectedTile));
		}

		private TileEntity CreateTile(int x, int y)
		{
			var entity = _contexts.tile.CreateEntity();
			entity.AddGameTile(Tile.Grass);
			entity.AddGameMapPosition(x, y);
			return entity;
		}
	}
}

