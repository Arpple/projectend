using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace End.Lobby.UI
{
	public class LobbyMain : MonoBehaviour
	{
		public GameObject PlayerContainer;

		private void Awake()
		{
			Assert.IsNotNull(PlayerContainer);
		}

		public void AddPlayer(LobbyPlayer player)
		{
			player.transform.SetParent(PlayerContainer.transform, false);
		}
	}
}
