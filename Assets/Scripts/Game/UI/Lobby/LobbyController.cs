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

		public void AddPlayer(LobbyPlayer player)
		{
			Main.AddPlayer(player);
			PlayerCount++;
		}

		public void RemovePlayer(LobbyPlayer player)
		{
			PlayerCount--;
		}

		public void SetupLocalPlayer(LobbyPlayer player)
		{
			Main.SetupLocalPlayer(player);
			player.PlayerName = Menu.GetPlayerName();
			player.IsReady = false;
		}

		public override void OnStartHost()
		{
			base.OnStartHost();

			Menu.gameObject.SetActive(false);
			Main.gameObject.SetActive(true);
		}

		public override void OnStopHost()
		{
			base.OnStopHost();

			Menu.gameObject.SetActive(true);
			Main.gameObject.SetActive(false);
		}
	}

}
