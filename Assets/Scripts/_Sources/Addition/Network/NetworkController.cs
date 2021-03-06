﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Network
{
	public class NetworkController : NetworkManager
	{
		public static NetworkController Instance;

		public UnityAction OnAllPlayerReadyCallback;
		public UnityAction<int> OnClientErrorCallback;
		public UnityAction<int> OnServerErrorCallback;
		public UnityAction<Player> ClientPlayerStartCallback;
		public UnityAction<Player> LocalPlayerStartCallback;
		public UnityAction ServerSceneChangedCallback;
		public UnityAction ClientSceneChangedCallback;

		[Header("Config")]
		public int MaxPlayer;

		[Header("Local")]
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

		public void ResetCallback()
		{
			OnAllPlayerReadyCallback = null;
			//OnClientErrorCallback = null;
			//OnServerErrorCallback = null;
			ClientPlayerStartCallback = null;
			LocalPlayerStartCallback = null;
			ServerSceneChangedCallback = null;
			ClientSceneChangedCallback = null;
		}

		public void Stop()
		{
			Shutdown();
		}

		public void OnStartClientPlayer(Player player)
		{
			AllPlayers.Add(player);
			if (ClientPlayerStartCallback != null) ClientPlayerStartCallback(player);
		}

		public void OnStartLocalPlayer(Player player)
		{
			if (LocalPlayerStartCallback != null) LocalPlayerStartCallback(player);
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

		public override void OnClientDisconnect(NetworkConnection conn)
		{
			base.OnClientDisconnect(conn);
			Stop();
			SceneManager.LoadScene(GameScene.Title.ToString());
		}

		public override void OnClientSceneChanged(NetworkConnection conn)
		{
			base.OnClientSceneChanged(conn);
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
			base.OnServerAddPlayer(conn, playerControllerId);
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

		public void ServerResetPlayerReadyStatus()
		{
			foreach(var p in AllPlayers)
			{
				p.IsClientSceneLoaded = false;
				p.IsReady = false;
			}
		}
		#endregion
	}
}