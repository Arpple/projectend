using System;
using UnityEngine;
using Entitas;
using Entitas.CodeGenerator.Api;

namespace End
{
	[Game]
	public class MapPositionComponent : IComponent
	{
		const float SIZE = 1.65f;

		public int X;
		public int Y;

		public Vector3 GetWorldPosition()
		{
			return new Vector3(X * SIZE, Y * SIZE, Y);
		}

		public int GetDistance(MapPositionComponent otherPosition)
		{
			return Math.Abs(X - otherPosition.X) + Math.Abs(Y - otherPosition.Y);
		}

		public bool IsEqual(MapPositionComponent otherPosition)
		{
			return X == otherPosition.X && Y == otherPosition.Y;
		}
	}
}