using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.UI;

namespace End.Lobby
{
	public class LobbyController : MonoBehaviour
	{
		public static LobbyController Instance;

		public GameObject PlayerContainer;
		public Button BackButton;
		public Button ReadyButton;
		public Button WaitButton;
		public LobbyPlayer LobbyPlayerPrefabs;

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(PlayerContainer);
			Assert.IsNotNull(BackButton);
			Assert.IsNotNull(ReadyButton);
			Assert.IsNotNull(WaitButton);
			Assert.IsNotNull(LobbyPlayerPrefabs);
		}

		private void Start()
		{
			ReadyButton.onClick.RemoveAllListeners();
			WaitButton.onClick.RemoveAllListeners();
		}

		public void AddPlayer(Player player)
		{
			player.transform.SetParent(PlayerContainer.transform, false);
			var lobbyPlayer = Instantiate(LobbyPlayerPrefabs).GetComponent<LobbyPlayer>();
			lobbyPlayer.SetPlayer(player);
		}

		public void SetLocalPlayer(Player player)
		{
			ReadyButton.onClick.AddListener(() =>
			{
				player.CmdSetReadyStatus(true);
				ReadyButton.gameObject.SetActive(false);
				WaitButton.gameObject.SetActive(true);
			});

			WaitButton.onClick.AddListener(() =>
			{
				player.CmdSetReadyStatus(false);
				ReadyButton.gameObject.SetActive(true);
				WaitButton.gameObject.SetActive(false);
			});
		}

		public void Back()
		{
			NetworkController.Instance.Stop();
		}
	}
}
