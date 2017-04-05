using UnityEngine;
using NUnit.Framework;
using Game;
using System;

namespace Test.System
{
	public class TestTileActionSystem : ContextsTest
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

			var tile = _contexts.game.CreateEntity();
			tile.AddGameView(_tileCon.gameObject);
			tile.AddGameTileAction(Assert.Pass);

			system.Execute();

			Assert.IsNotNull(_tileCon.TileAction);
		}

		[Test]
		public void ActionRemovedWhenComponentRemoved()
		{
			var system = new TileActionSystem(_contexts);

			var tile = _contexts.game.CreateEntity();
			tile.AddGameView(_tileCon.gameObject);
			tile.AddGameTileAction(Assert.Fail);
			tile.RemoveGameTileAction();

			system.Execute();

			Assert.IsNull(_tileCon.TileAction);
		}
	}
}
