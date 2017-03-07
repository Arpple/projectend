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

		public void Create()
		{
			_map.SetMap(5, 5, Tile.Grass);

			var pos = new End.MapPositionComponent();
			pos.X = 5;
			pos.Y = 5;

			Assert.IsTrue(
				_map.GetTile(5, 5) == Tile.Grass
				&& _map.GetTile(pos) == Tile.Grass
			);
		}
	}
}

