using System.Linq;
using NUnit.Framework;
using End.Game;

namespace End.Test
{
	public class TestCreateTileGraphSystem
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

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

			Assert.AreEqual(leftTile, originTile.tileGraph.Left);
			Assert.AreEqual(rightTile, originTile.tileGraph.Right);
			Assert.AreEqual(upTile, originTile.tileGraph.Up);
			Assert.AreEqual(downTile, originTile.tileGraph.Down);

			var connectedTiles = originTile.tileGraph.GetConnectedTiles();

			Assert.IsTrue(connectedTiles.Contains(leftTile));
			Assert.IsTrue(connectedTiles.Contains(rightTile));
			Assert.IsTrue(connectedTiles.Contains(upTile));
			Assert.IsTrue(connectedTiles.Contains(downTile));
			Assert.IsFalse(connectedTiles.Contains(unconnectedTile));
		}

		private GameEntity CreateTile(int x, int y)
		{
			var entity = _contexts.game.CreateEntity();
			entity.AddTile(Tile.Grass);
			entity.AddMapPosition(x, y);
			return entity;
		}
	}
}

