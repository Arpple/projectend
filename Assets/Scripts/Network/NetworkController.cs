using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace End
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

		public delegate void ClientPlayerStartCallback(Player player);
		public event ClientPlayerStartCallback OnClientPlayerStartCallback;

		public delegate void LocalPlayerStartCallback(Player player);
		public event LocalPlayerStartCallback OnLocalPlayerStartCallback;

		[Header("Config")]
		public int MaxPlayer;

		[Header("Local Player")]
		public string LocalPlayerName;
		public string LocalPlayerIconPath;
		public Game.Character SelectedCharacter;

		private void Awake()
		{
			if(Instance != null)
			{
				DestroyImmediate(gameObject);
				return;
			}
			Instance = this;
		}

		public void Stop()
		{
			Shutdown();
		}

		public void OnStartClientPlayer(Player player)
		{
			if (OnClientPlayerStartCallback != null) OnClientPlayerStartCallback(player);
		}

		public void OnStartLocalPlayer(Player player)
		{
			if (OnLocalPlayerStartCallback != null) OnLocalPlayerStartCallback(player);
		}

		#region Client
		public override void OnStartClient(NetworkClient client)
		{
			base.OnStartClient(client);

			SelectedCharacter = Game.Character.None;
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
		#endregion

		#region Server
		public int ConnectionCount;

		/// <summary>
		/// The maximum connections, override version of default maxconnections
		/// which is not working
		/// </summary>
		private int _maxConnections;
		private bool _isPlaying;

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

		public void StartGame()
		{
			_isPlaying = true;
		}

		public override void OnServerConnect(NetworkConnection conn)
		{
			base.OnServerConnect(conn);

			if(_isPlaying)
			{
				conn.Send(MsgGamePlaying, new NormalMessage());
				return;
			}

			if(IsMaxConnected())
			{
				conn.Send(MsgServerFull, new NormalMessage());
				return;
			}

			ConnectionCount++;
		}

		/// <summary>
		/// This hook is invoked when a server is started - including when a host is started.
		/// </summary>
		public override void OnStartServer()
		{
			base.OnStartServer();

			_maxConnections = MaxPlayer;
			_isPlaying = false;
			ConnectionCount = 0;
			Player.ServerSetup();
		}

		/// <summary>
		/// Invoked on server when all player.isReady is true
		/// </summary>
		public void OnServerAllPlayerReady()
		{
			Assert.IsTrue(Player.AllPlayers.TrueForAll(p => p.IsReady));

			if (OnAllPlayerReadyCallback != null) OnAllPlayerReadyCallback();
		}

		public override void OnServerSceneChanged(string sceneName)
		{
			base.OnServerSceneChanged(sceneName);

			if (SceneManager.GetActiveScene().name != Scene.Lobby.ToString())
			{
				maxConnections = numPlayers;
				Debug.Log("Lock connection to " + numPlayers);
			}
		}

		public override void OnServerError(NetworkConnection conn, int errorCode)
		{
			base.OnServerError(conn, errorCode);
			if (OnServerErrorCallback != null) OnServerErrorCallback(errorCode);
		}
		#endregion

		#region Message
		class NormalMessage : MessageBase { }
		public static short MsgServerFull = MsgType.Highest + 1;
		public static short MsgGamePlaying = MsgType.Highest + 1;
		#endregion
	}
}
