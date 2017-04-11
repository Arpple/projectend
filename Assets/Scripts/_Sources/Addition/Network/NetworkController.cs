using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace Network
{
	public class NetworkController : NetworkManager
	{
		public static NetworkController Instance;

		public delegate void AllPlayerReadyCallback();
		public event AllPlayerReadyCallback OnAllPlayerReadyCallback;

		public delegate void ClientErrorCallback(int errorCode);
		public event ClientErrorCallback OnClientErrorCallback;

		public delegate void ServerErrorCallback(int errorCode);
		public event ServerErrorCallback OnServerErrorCallback;

		public delegate void PlayerAction(Player player);
		public event PlayerAction OnClientPlayerStartCallback;
		public event PlayerAction OnLocalPlayerStartCallback;

		public UnityAction ServerSceneChangedCallback;
		public UnityAction ClientSceneChangedCallback;

		[Header("Config")]
		public int MaxPlayer;

		[Header("Local Player")]
		public string LocalPlayerName;
		public string LocalPlayerIconPath;
		public Player LocalPlayer;

		public List<Player> AllPlayers;

		public static bool IsServer
		{
			get { return NetworkServer.active; }
		}

		private void Awake()
		{
			Instance = this;
			AllPlayers = new List<Player>();
		}

		private void Start()
		{
			CrossSceneObject.AddObject(gameObject);
		}

		public void Stop()
		{
			Shutdown();
		}

		public void OnStartClientPlayer(Player player)
		{
			AllPlayers.Add(player);
			if (OnClientPlayerStartCallback != null) OnClientPlayerStartCallback(player);
		}

		public void OnStartLocalPlayer(Player player)
		{
			if (OnLocalPlayerStartCallback != null) OnLocalPlayerStartCallback(player);
			LocalPlayer = player;
		}

		public void OnDisconnectPlayer(Player player)
		{
			AllPlayers.Remove(player);
		}

		#region Client
		public override void OnStartClient(NetworkClient client)
		{
			base.OnStartClient(client);
		}

		/// <summary>
		/// Called on clients when a network error occurs.
		/// </summary>
		/// <param name="conn">Connection to a server.</param>
		/// <param name="errorCode">Error code.</param>
		public override void OnClientError(NetworkConnection conn, int errorCode)
		{
			base.OnClientError(conn, errorCode);
			if (OnClientErrorCallback != null) OnClientErrorCallback(errorCode);
		}

		public override void OnClientSceneChanged(NetworkConnection conn)
		{
			base.OnClientSceneChanged(conn);

			foreach (var player in AllPlayers)
			{
				player.IsReady = false;
			}

			if (ClientSceneChangedCallback != null) ClientSceneChangedCallback();
		}
		#endregion

		#region Server
		public int ConnectionCount;

		/// <summary>
		/// The maximum connections, override version of default maxConnections
		/// which is not working
		/// </summary>
		private int _maxConnections;

		private bool _gameStarted;
		private int _playerIdCounter;

		/// <summary>
		/// Check if connection is now at maximum
		/// </summary>
		/// <returns>
		///   <c>true</c> if [is maximum connected]; otherwise, <c>false</c>.
		/// </returns>
		public bool IsMaxConnected()
		{
			Assert.IsTrue(ConnectionCount <= _maxConnections);
			return ConnectionCount == _maxConnections;
		}

		/// <summary>
		/// Closes the connection because game is now running
		/// </summary>
		public void StartGame()
		{
			Debug.Log("Start Game");
			_gameStarted = true;
		}

		/// <summary>
		/// Called on the server when a new client connects.
		/// </summary>
		/// <param name="conn">Connection from client.</param>
		public override void OnServerConnect(NetworkConnection conn)
		{
			base.OnServerConnect(conn);

			if (_gameStarted)
			{
				conn.SendGameStarted();
				return;
			}

			if (IsMaxConnected())
			{
				conn.SendServerIsFull();
				return;
			}

			ConnectionCount++;
		}

		/// <summary>
		/// Called on the server when a client disconnects.
		/// </summary>
		/// <param name="conn">Connection from client.</param>
		public override void OnServerDisconnect(NetworkConnection conn)
		{
			base.OnServerDisconnect(conn);

			ConnectionCount--;
		}

		/// <summary>
		/// This hook is invoked when a server is started - including when a host is started.
		/// </summary>
		public override void OnStartServer()
		{
			base.OnStartServer();

			_maxConnections = MaxPlayer;
			_gameStarted = false;
			ConnectionCount = 0;
			Player.ServerSetup();
		}

		public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
		{
			if (SceneManager.GetActiveScene().name == Scene.Lobby.ToString())
			{
				base.OnServerAddPlayer(conn, playerControllerId);
			}
		}

		/// <summary>
		/// Invoked on server when all player.isReady is true
		/// </summary>
		public void OnServerAllPlayerReady()
		{
			Assert.IsTrue(AllPlayers.TrueForAll(p => p.IsReady));

			if (OnAllPlayerReadyCallback != null) OnAllPlayerReadyCallback();
		}

		public override void OnServerSceneChanged(string sceneName)
		{
			base.OnServerSceneChanged(sceneName);
			if (ServerSceneChangedCallback != null) ServerSceneChangedCallback();
		}

		public override void OnServerError(NetworkConnection conn, int errorCode)
		{
			base.OnServerError(conn, errorCode);
			if (OnServerErrorCallback != null) OnServerErrorCallback(errorCode);
		}
		#endregion
	}
}