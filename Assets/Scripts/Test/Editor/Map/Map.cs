using NUnit.Framework;
using UnityEngine;

namespace End.Test
{
	public class Map
	{
		private End.Map _map;

		[SetUp]
		public void Init()
		{
			_map = ScriptableObject.CreateInstance<End.Map>();
		}

		[Test]
		public void Create()
		{
			_map.SetMap(5, 5, Tile.Grass);
			Assert.AreEqual(Tile.Grass, _map.GetTile(4, 4));

			var pos = new End.MapPositionComponent();
			pos.X = 4;
			pos.Y = 4;
			Assert.AreEqual(Tile.Grass, _map.GetTile(pos));
		}

		[Test]
		public void SetTile()
		{
			_map.SetMap(5, 5, Tile.Grass);
			_map.SetTile(1, 1, Tile.None);

			Assert.AreEqual(Tile.None, _map.GetTile(1, 1));
		}
	}
}

