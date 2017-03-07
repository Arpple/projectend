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

			var pos = new End.MapPositionComponent();
			pos.X = 4;
			pos.Y = 4;

			Assert.IsTrue(
				_map.GetTile(4, 4) == Tile.Grass
				&& _map.GetTile(pos) == Tile.Grass
			);
		}

		[Test]
		public void SetTile()
		{
			_map.SetMap(5, 5, Tile.Grass);
			_map.SetTile(1, 1, Tile.None);

			Assert.IsTrue(_map.GetTile(1, 1) == Tile.None);
		}
	}
}

