using UnityEngine.Assertions;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace End.Lobby
{
	public class LobbyController : NetworkLobbyManager
	{
		public static LobbyController Instance;

		public GameObject PlayerContainer;
		public Button BackButton;

		public Lounge.LoungeData LoungeData
		{
			get { return Lounge.LoungeData.Instance; }
		}

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(PlayerContainer);
			Assert.IsNotNull(BackButton);
		}

		private void Start()
		{
			#if DEBUG
			//quickly go back to lounge for debugging purpose
			if(LoungeData == null)
			{
				SceneManager.LoadScene(Scene.Lounge.ToString());
				Destroy(gameObject);
				return;
			}
			#endif

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

		public void Back()
		{
			if (LoungeData.IsHost)
			{
				StopHost();
			}
			else
			{
				StopClient();
			}
			SceneManager.LoadScene(Scene.Lounge.ToString());
			Destroy(gameObject);
		}

		#region Client
		public override void OnLobbyClientSceneChanged(NetworkConnection conn)
		{
			if(SceneManager.GetActiveScene().name == Scene.Lounge.ToString())
			{
				return;
			}

			base.OnLobbyClientSceneChanged(conn);
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
