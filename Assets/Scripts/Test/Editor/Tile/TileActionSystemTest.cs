using NUnit.Framework;
using UnityEngine;

namespace Test.TileTest
{
	public class TileActionSystemTest : ContextsTest
	{
		private TileController _tileCon;

		[SetUp]
		public void Init()
		{
			_tileCon = new GameObject().AddComponent<TileController>();
		}

		[Test]
		public void ActionRegisteredWhenComponentAdded()
		{
			var system = new TileActionSystem(_contexts);

			var tile = _contexts.tile.CreateEntity();
			tile.AddView(_tileCon.gameObject);
			tile.AddTileAction(Assert.Pass);

			system.Execute();

			Assert.IsNotNull(_tileCon.TileAction);
		}

		[Test]
		public void ActionRemovedWhenComponentRemoved()
		{
			var system = new TileActionSystem(_contexts);

			var tile = _contexts.tile.CreateEntity();
			tile.AddView(_tileCon.gameObject);
			tile.AddTileAction(Assert.Fail);
			tile.RemoveTileAction();

			system.Execute();

			Assert.IsNull(_tileCon.TileAction);
		}
	}
}
