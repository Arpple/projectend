using System;

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
