using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

namespace End.Lobby.UI
{
	public class LobbyController : NetworkLobbyManager
	{
		public static LobbyController Instance;

		public LobbyMenu Menu;
		public LobbyMain Main;
		public int PlayerCount;

		private LobbyPlayer _localPlayer;
		private int _playerIdCounter = 0;

		private void Awake()
		{
			Instance = this;
			PlayerCount = 0;

			Assert.IsNotNull(Menu);
			Assert.IsNotNull(Main);
		}

		private void Start()
		{
			Menu.gameObject.SetActive(true);
			Main.gameObject.SetActive(false);
		}

		#region Client
		public void AddPlayer(LobbyPlayer player)
		{
			Main.AddPlayer(player);
			PlayerCount++;
		}

		public void RemovePlayer()
		{
			PlayerCount--;
		}

		public void SetupLocalPlayer(LobbyPlayer player)
		{
			_localPlayer = player;
			Main.SetupLocalPlayer(player);
			player.CmdSetName(Menu.GetPlayerName());
			player.CmdSetStatus(false);
		}

		public override void OnStartClient(NetworkClient lobbyClient)
		{
			base.OnStartClient(lobbyClient);

			Menu.gameObject.SetActive(false);
			Main.gameObject.SetActive(true);
		}

		public override void OnStopClient()
		{
			base.OnStopClient();

			Menu.gameObject.SetActive(true);
			Main.gameObject.SetActive(false);
		}
		#endregion

		#region Server
		/// <summary>
		/// Called when [start host].
		/// </summary>
		public override void OnStartHost()
		{
			base.OnStartHost();

			_playerIdCounter = 0;
		}

		/// <summary>
		/// This is called on the server when it is told that a client has finished switching from the lobby scene to a game player scene.
		/// </summary>
		/// <param name="lobbyPlayer">The lobby player object.</param>
		/// <param name="gamePlayer">The game player object.</param>
		/// <returns>
		/// False to not allow this player to replace the lobby player.
		/// </returns>
		public override bool OnLobbyServerSceneLoadedForPlayer(GameObject lobbyPlayer, GameObject gamePlayer)
		{
			base.OnLobbyServerSceneLoadedForPlayer(lobbyPlayer, gamePlayer);

			if (lobbyPlayer == _localPlayer)
			{
				Game.Player.PlayerCount = PlayerCount;
			}

			var gp = gamePlayer.GetComponent<Game.Player>();
			var lp = lobbyPlayer.GetComponent<LobbyPlayer>();

			if(_localPlayer.isServer)
			{
				gp.PlayerId = GeneratePlayerId();
			}

			return true;
		}

		private int GeneratePlayerId()
		{
			_playerIdCounter++;
			return _playerIdCounter;
		}
		#endregion
	}

}
