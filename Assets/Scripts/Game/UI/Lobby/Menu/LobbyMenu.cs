using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Lobby.UI
{
	public class LobbyMenu : MonoBehaviour
	{
		public LobbyPlayerProfile PlayerProfile;
		public Button HostButton;
		public Button JoinButton;
		public LobbyMenuConnectionDialogue ConnectionDialogue;

		public LobbyController LobbyController
		{
			get { return LobbyController.Instance; }
		}

		private void Awake()
		{
			Assert.IsNotNull(PlayerProfile);
			Assert.IsNotNull(HostButton);
			Assert.IsNotNull(JoinButton);
			Assert.IsNotNull(ConnectionDialogue);
		}

		private void Start()
		{
			ConnectionDialogue.CloseDialogueCallback = () =>
			{
				HostButton.interactable = true;
				JoinButton.interactable = true;
			};
		}

		public string GetPlayerName()
		{
			return PlayerProfile.PlayerName.text;
		}

		public void Host()
		{
			LobbyController.StartHost();
			Debug.Log("Host");
		}

		public void Join()
		{
			ConnectionDialogue.gameObject.SetActive(true);
			HostButton.interactable = false;
			JoinButton.interactable = false;
		}
	}
}

