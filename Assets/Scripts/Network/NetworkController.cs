using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

namespace End.Network
{
	public class NetworkController : NetworkManager
	{
		public static NetworkController Instance;

		[Header("Local Player")]
		public string LocalPlayerName;
		public string LocalPlayerIconPath;

		private void Awake()
		{
			Instance = this;
		}

		public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
		{
			var playerObject = Instantiate(playerPrefab);

			var player = playerObject.GetComponent<Player>();
			Assert.IsNotNull(player);
			Lobby.LobbyController.Instance.AddPlayer(player);

			NetworkServer.AddPlayerForConnection(conn, playerObject, playerControllerId);
		}
	}
}
