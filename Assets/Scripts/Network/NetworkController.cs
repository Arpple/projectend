using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

namespace End
{
	public class NetworkController : NetworkManager
	{
		public static NetworkController Instance;

		public delegate void AllPlayerReadyCallback();
		public event AllPlayerReadyCallback OnAllPlayerReadyCallback;

		public delegate void ClientErrorCallback(int errorCode);
		public event ClientErrorCallback OnClientErrorCallback;

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

		public override void OnStartClient(NetworkClient client)
		{
			base.OnStartClient(client);

			Player.AllPlayers = new List<Player>();
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

		#region Server		
		/// <summary>
		/// This hook is invoked when a server is started - including when a host is started.
		/// </summary>
		public override void OnStartServer()
		{
			base.OnStartServer();

			maxConnections = MaxPlayer;
		}

		/// <summary>
		/// Invoked on server when all player.isReady is true
		/// </summary>
		public void OnServerAllPlayerReady()
		{
			Assert.IsTrue(Player.AllPlayers.TrueForAll(p => p.IsReady));

			if (OnAllPlayerReadyCallback != null) OnAllPlayerReadyCallback();
			Debug.Log("All Ready");
		}
		#endregion
	}
}
