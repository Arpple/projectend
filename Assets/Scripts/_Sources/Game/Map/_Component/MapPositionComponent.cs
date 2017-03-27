using System;
using UnityEngine;
using Entitas;
using System.Linq;

namespace End.Game
{
	[Game]
	public class MapPositionComponent : IComponent
	{
		const float SIZE = 1.63f;

		public int x;
		public int y;

		public Vector3 GetWorldPosition()
		{
			return new Vector3(x * SIZE, y * SIZE, y);
		}

		public int GetDistance(MapPositionComponent otherPosition)
		{
			return Math.Abs(x - otherPosition.x) + Math.Abs(y - otherPosition.y);
		}

		public bool IsEqual(MapPositionComponent otherPosition)
		{
			return x == otherPosition.x && y == otherPosition.y;
		}

		public override string ToString()
		{
			return "(" + x + "," + y + ")";
		}

		public GameEntity GetTile()
		{
			var context = Contexts.sharedInstance.game;
			return context.GetEntities(GameMatcher.Tile)
				.Where(t => t.mapPosition.IsEqual(this))
				.First();
		}
	}
}