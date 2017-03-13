using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Lobby.UI
{
	public class LobbyMenu : MonoBehaviour
	{
		public Button HostButton;
		public Button JoinButton;
		public LobbyMenuConnectionDialogue ConnectionDialogue;

		public LobbyController LobbyController
		{
			get { return LobbyController.Instance; }
		}

		private void Start()
		{
			Assert.IsNotNull(ConnectionDialogue);
			ConnectionDialogue.CloseDialogueCallback = () =>
			{
				HostButton.interactable = true;
				JoinButton.interactable = true;
			};
		}

		public void Host()
		{
			//LobbyController.StartHost();
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

