using UnityEngine.Assertions;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace End.Lobby
{
	public class LobbyController : NetworkLobbyManager
	{
		public static LobbyController Instance;

		public GameObject PlayerContainer;

		public Lounge.LoungeToLobby LoungeData
		{
			get { return Lounge.LoungeToLobby.Instance; }
		}

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(PlayerContainer);
		}

		private void Start()
		{
			Assert.IsNotNull(LoungeData);

			if (LoungeData.IsHost)
			{
				StartHost();
			}
			else
			{
				networkAddress = LoungeData.ConnectingIpAddress;
				StartClient();
			}
		}

		public void AddPlayer(LobbyPlayer player)
		{
			player.transform.SetParent(PlayerContainer.transform, false);
		}

		#region Client
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
