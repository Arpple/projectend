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

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(Menu);
			Assert.IsNotNull(Main);
		}

		public void AddPlayer(LobbyPlayer player)
		{
			Main.AddPlayer(player);
			player.PlayerName = Menu.GetPlayerName();
			player.PlayerStatus = LobbyPlayer.Status.Wait;
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
