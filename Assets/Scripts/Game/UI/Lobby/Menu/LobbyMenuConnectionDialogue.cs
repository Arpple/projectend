using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Lobby.UI
{
	public class LobbyMenuConnectionDialogue : MonoBehaviour
	{
		public delegate void CloseDialogueAction();

		public LobbyMenu Menu;
		public Button BackButton;
		public Button JoinButton;
		public Text IpInputField;
		public CloseDialogueAction CloseDialogueCallback;

		public LobbyController LobbyController
		{
			get { return LobbyController.Instance; }
		}

		private void Awake()
		{
			Assert.IsNotNull(Menu);
			Assert.IsNotNull(BackButton);
			Assert.IsNotNull(JoinButton);
			Assert.IsNotNull(IpInputField);
		}

		private void Update()
		{
			JoinButton.interactable = GetIpAddress() != "";
		}

		public string GetIpAddress()
		{
			return IpInputField.text;
		}

		public void Back()
		{
			gameObject.SetActive(false);
			if(CloseDialogueCallback != null) CloseDialogueCallback();
		}

		public void Join()
		{
			gameObject.SetActive(false);
			if (CloseDialogueCallback != null) CloseDialogueCallback();
			LobbyController.networkAddress = IpInputField.text;
			//LobbyController.StartClient();
			Debug.Log("Join Server : " + IpInputField.text);
		}
	}

}
