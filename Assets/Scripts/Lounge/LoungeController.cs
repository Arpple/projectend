using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using End.UI;


namespace End.Lounge
{
	public class LoungeController : MonoBehaviour
	{
		public LoungeToLobby PlayerSetting;
		public Icon PlayerIcon;
		public InputField PlayerNameInputField;
		public Button HostButton;
		public Button JoinButton;
		public ConnectionDialogue ConnectionDialogue;

		private void Awake()
		{
			Assert.IsNotNull(PlayerSetting);
			Assert.IsNotNull(PlayerIcon);
			Assert.IsNotNull(PlayerNameInputField);
			Assert.IsNotNull(HostButton);
			Assert.IsNotNull(JoinButton);
			Assert.IsNotNull(ConnectionDialogue);
		}

		private void Start()
		{
			//set profile
			var playerIconImage = Resources.Load<Sprite>(PlayerSetting.PlayerIconPath);
			if (playerIconImage != null) PlayerIcon.SetImage(playerIconImage);
			PlayerNameInputField.text = PlayerSetting.PlayerName;
			PlayerNameInputField.onEndEdit.AddListener((s) => PlayerSetting.PlayerName = PlayerNameInputField.text);

			//set dialogue event
			ConnectionDialogue.OnBackButton += () => ToggleButton(true);
			ConnectionDialogue.OnJoinButton += () =>
			{
				ToggleButton(true);

				Connect(false);
			};
		}

		public void Host()
		{
			Connect(true);
		}

		public void Join()
		{
			ConnectionDialogue.gameObject.SetActive(true);
			ToggleButton(false);
		}

		/// <summary>
		/// Toggles button interactable.
		/// </summary>
		/// <param name="isEnable">if set to <c>true</c> [is enable].</param>
		private void ToggleButton(bool isEnable)
		{
			JoinButton.interactable = isEnable;
			HostButton.interactable = isEnable;
		}

		private void Connect(bool isHost)
		{
			var data = LoungeToLobby.Instance;
			data.PlayerName = PlayerNameInputField.text;
			data.IsHost = isHost;

			if(isHost)
			{
				Debug.Log("Starting Host");
			}
			else
			{
				data.ConnectingIpAddress = ConnectionDialogue.IpAddress;
				Debug.Log("Connecting to " + ConnectionDialogue.IpAddress);
			}

			SceneManager.LoadScene(Scene.Lobby.ToString());
		}
	}

}
