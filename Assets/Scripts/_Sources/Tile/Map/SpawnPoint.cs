using System;
using UnityEngine;

public partial class Map : ScriptableObject
{
	[Serializable]
	private class SpawnPoint
	{
		public int x;
		public int y;

		public SpawnPoint(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
}
