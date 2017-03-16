using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using End.UI;

namespace End.Lounge
{
	public class LoungeController : MonoBehaviour
	{
		public Icon PlayerIcon;
		public InputField PlayerNameInputField;
		public Button HostButton;
		public Button JoinButton;
		public ConnectionDialogue ConnectionDialogue;

		public NetworkController NetCon
		{
			get { return NetworkController.Instance; }
		}

		private void Awake()
		{
			Assert.IsNotNull(PlayerIcon);
			Assert.IsNotNull(PlayerNameInputField);
			Assert.IsNotNull(HostButton);
			Assert.IsNotNull(JoinButton);
			Assert.IsNotNull(ConnectionDialogue);
		}

		private void Start()
		{
			//set profile
			var playerIconImage = Resources.Load<Sprite>(NetCon.LocalPlayerIconPath);
			if (playerIconImage != null) PlayerIcon.SetImage(playerIconImage);
			PlayerNameInputField.text = NetCon.LocalPlayerName;
			PlayerNameInputField.onEndEdit.AddListener((s) => NetCon.LocalPlayerName = PlayerNameInputField.text);

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
			//SceneManager.LoadScene(Scene.Lobby.ToString());

			if (isHost)
			{
				Debug.Log("Starting Host");
				NetCon.StartHost();
			}
			else
			{
				var ip = ConnectionDialogue.IpAddress;
				NetCon.networkAddress = ip;
				Debug.Log("Connecting to " + ip);
				NetCon.StartClient();
			}
		}
	}

}
