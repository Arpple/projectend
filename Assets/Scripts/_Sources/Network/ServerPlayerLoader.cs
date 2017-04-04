using UnityEngine;
using System.Collections;

namespace End
{
	public class ServerPlayerLoader : PlayerLoader
	{
		private readonly int _targetPlayerCount;
		private int _loadedPlayerCount = 0;

		public ServerPlayerLoader(int targetPlayerCount)
		{
			_targetPlayerCount = targetPlayerCount;
		}

		public void LoadPlayer()
		{
			_loadedPlayerCount++;
		}

		public override bool IsReady()
		{
			return _loadedPlayerCount == _targetPlayerCount;
		}
	}
}
