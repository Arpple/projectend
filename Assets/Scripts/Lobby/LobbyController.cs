using UnityEngine.Assertions;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace End.Network
{
	public class LobbyController : NetworkLobbyManager
	{
		public static LobbyController Instance;

		public Lounge.LoungeToLobby LoungeData
		{
			get { return Lounge.LoungeToLobby.Instance; }
		}

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(LoungeData);
		}

		private void Start()
		{
			if(LoungeData.IsHost)
			{
				StartHost();
			}
			else
			{
				networkAddress = LoungeData.ConnectingIpAddress;
				StartClient();
			}

			Destroy(LoungeData.gameObject);
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
