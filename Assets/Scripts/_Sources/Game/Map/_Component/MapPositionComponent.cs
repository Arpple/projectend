using System;
using UnityEngine;
using Entitas;
using System.Linq;
using Entitas.CodeGeneration.Attributes;

public struct Position : IEquatable<Position>
{
	public int x;
	public int y;
	
	public Position(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public bool Equals(Position other)
	{
		return other.x == x && other.y == y;
	}

	public override bool Equals(object obj)
	{
		if(obj == null || obj.GetType() != GetType() || obj.GetHashCode() != GetHashCode())
		{
			return false;
		}

		var other = (Position)obj;
		return this.Equals(other);
	}

	public override int GetHashCode()
	{
		return (x << 8) + y;
	}
}

namespace Game
{
	[Unit, Tile]
	public class MapPositionComponent : IComponent
	{
		const float SIZE = 1f;

		[EntityIndex]
		public Position Value;
		public int x { get { return Value.x; } }
		public int y { get { return Value.y; } }

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
	}
}

public partial class UnitEntity
{
	public void AddGameMapPosition(int x, int y)
	{
		AddGameMapPosition(new Position(x, y));
	}

	public void ReplaceGameMapPosition(int x, int y)
	{
		ReplaceGameMapPosition(new Position(x, y));
	}
}

public partial class TileEntity
{
	public void AddGameMapPosition(int x, int y)
	{
		AddGameMapPosition(new Position(x, y));
	}

	public void ReplaceGameMapPosition(int x, int y)
	{
		ReplaceGameMapPosition(new Position(x, y));
	}
}