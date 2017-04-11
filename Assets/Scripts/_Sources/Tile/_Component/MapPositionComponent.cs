using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

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

public partial class UnitEntity
{
	public void AddMapPosition(int x, int y)
	{
		AddMapPosition(new Position(x, y));
	}

	public void ReplaceMapPosition(int x, int y)
	{
		ReplaceMapPosition(new Position(x, y));
	}
}

public partial class TileEntity
{
	public void AddMapPosition(int x, int y)
	{
		AddMapPosition(new Position(x, y));
	}

	public void ReplaceMapPosition(int x, int y)
	{
		ReplaceMapPosition(new Position(x, y));
	}
}