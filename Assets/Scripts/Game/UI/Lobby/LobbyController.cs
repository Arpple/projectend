using UnityEngine;
using UnityEngine.Networking;

namespace End.Lobby.UI
{
	public class LobbyController : NetworkLobbyManager
	{
		public static LobbyController Instance;

		private void Start()
		{
			Instance = this;
		}
	}

}
