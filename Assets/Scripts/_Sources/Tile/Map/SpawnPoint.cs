using System;
using UnityEngine;

public partial class Map : ScriptableObject
{
	[Serializable]
	private class SpawnPoint
	{
		[SerializeField] public int x;
		[SerializeField] public int y;

		public SpawnPoint(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
}
