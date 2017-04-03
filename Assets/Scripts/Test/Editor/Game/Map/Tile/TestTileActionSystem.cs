using UnityEngine;
using NUnit.Framework;
using End.Game;
using System;

namespace End.Test.System
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
			tile.AddView(_tileCon.gameObject);
			tile.AddTileAction((e) => Assert.Pass());

			system.Execute();

			Assert.IsNotNull(_tileCon.TileAction);
		}

		[Test]
		public void ActionRemovedWhenComponentRemoved()
		{
			var system = new TileActionSystem(_contexts);

			var tile = _contexts.game.CreateEntity();
			tile.AddView(_tileCon.gameObject);
			tile.AddTileAction((e) => Assert.Fail());
			tile.RemoveTileAction();

			system.Execute();

			Assert.IsNull(_tileCon.TileAction);
		}
	}
}
