using System;
using UnityEngine;
using Entitas;
using System.Linq;

namespace Game
{
	[Game]
	public class MapPositionComponent : IComponent
	{
		const float SIZE = 1f;

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

		public bool Equals(MapPositionComponent other)
		{
			return x == other.x && y == other.y;
		}

		public override string ToString()
		{
			return "(" + x + "," + y + ")";
		}

		public GameEntity GetTile()
		{
			var context = Contexts.sharedInstance.game;
			return context.GetEntities(GameMatcher.GameTile)
				.Where(t => t.gameMapPosition.Equals(this))
				.First();
		}
	}
}