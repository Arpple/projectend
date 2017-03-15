using UnityEngine.Assertions;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace End.Network
{
	public class NetworkController : NetworkLobbyManager
	{
		public static NetworkController Instance;

		private void Awake()
		{
			Instance = this;
		}

		public void JoinServer(string ip)
		{
			networkAddress = ip;
			StartClient();
		}

		#region Client
		public override void OnStartClient(NetworkClient lobbyClient)
		{
			base.OnStartClient(lobbyClient);
		}
		#endregion

		#region Server
		public override void OnLobbyStartHost()
		{
			base.OnLobbyStartHost();
			maxConnections = maxPlayers;
		}
		#endregion
	}
}
