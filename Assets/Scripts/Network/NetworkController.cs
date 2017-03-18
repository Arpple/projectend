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
		/// <summary>
		/// This hook is invoked when a server is started - including when a host is started.
		/// </summary>
		public override void OnStartServer()
		{
			base.OnStartServer();

			maxConnections = MaxPlayer;
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
	}
}
