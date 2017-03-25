using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game
{
	/// <summary>
	/// Utility command/shortcut class
	/// </summary>
	public static class GameUtil
	{
		public static bool IsLocalPlayerTurn
		{
			get { return GameEntity.LocalPlayer.player.PlayerId == GameEntity.Context.playingOrder.CurrentPlayerId; }
		}
	}

}
