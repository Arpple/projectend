using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using End.UI;
using UnityEngine.Networking;
using End.UI.Dialogues;
using System;
using System.Collections;
using Entitas.Unity.VisualDebugging;

namespace End.Lounge
{
	public class LoungeController : MonoBehaviour
	{
		public Icon PlayerIcon;
		public InputField PlayerNameInputField;
		public Button HostButton;
		public Button JoinButton;
		public ConnectionDialogue ConnectionDialogue;

        public Dialogue WarningDialog, ConnectingDialog;

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
			//clear old observer
			foreach (var observer in FindObjectsOfType<ContextObserverBehaviour>())
			{
				Destroy(observer.gameObject);
			}

			//set profile
			var playerIconImage = Resources.Load<Sprite>(NetCon.LocalPlayerIconPath);
			if (playerIconImage != null) PlayerIcon.SetImage(playerIconImage);
			PlayerNameInputField.text = NetCon.LocalPlayerName;
			PlayerNameInputField.onEndEdit.AddListener((s) => NetCon.LocalPlayerName = PlayerNameInputField.text);

			//set dialogue event
			ToggleButton(true);
			ConnectionDialogue.OnBackButton += () => ToggleButton(true);
			ConnectionDialogue.OnJoinButton += () =>
			{
				ToggleButton(true);

				Connect(false);
			};

			NetCon.OnClientErrorCallback += ConnectError;

			this.WarningDialog.OnDialogueClose += () => ToggleButton(true);
			this.ConnectingDialog.OnDialogueClose += () => ToggleButton(true);
		}

		private void OnDestroy()
		{
			NetCon.OnClientErrorCallback -= ConnectError;
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
			ToggleButton(false);
			if (isHost)
			{
				Debug.Log("Starting Host");
				if (NetCon.StartHost() == null)
				{
					ToggleButton(true);
                    this.WarningDialog.Open("Alert!", "You can't be Host!" + Environment.NewLine + "Why ? Don't Ask me!!!");
                }
			}
			else
			{

                //TODO: show connecting dialogue fake 3sec :D
                this.ConnectingDialog.Open();
                StartCoroutine(Wait3Sec());

                //TODO : then try to real connect
                var ip = ConnectionDialogue.IpAddress;
				Debug.Log("Connecting to " + ip);
				NetCon.networkAddress = ip;
				var client = NetCon.StartClient();
				client.RegisterHandler(NetMessage .MsgServerFull, ServerFullHandler);
				client.RegisterHandler(NetMessage.MsgGameStarted, ServerIsPlayingHandler);
				client.RegisterHandler(NetMessage.MsgPlayerCount, (m) => NetworkController.Instance.ConnectionCount = m.ReadMessage<NetMessage.PlayerCountMessage>().Count);
			}
		}

        private IEnumerator Wait3Sec() {
            yield return new WaitForSeconds(3f);
        }

        public void ConnectError(int errorCode)
		{
			if (errorCode == (int)NetworkError.Timeout)
			{
				Debug.Log("Time Out");
                this.WarningDialog.Open("Alert!", "I think your connection has an error." + Environment.NewLine + "But, Don't Ask me why.");
            }
		}

		public void ServerFullHandler(NetworkMessage msg)
		{
			msg.conn.Disconnect();
			Debug.Log("Server is full");
            this.WarningDialog.Open("Alert!", "Hey ! Server is full !" + Environment.NewLine + "Go other room");
        }

		public void ServerIsPlayingHandler(NetworkMessage msg)
		{
			msg.conn.Disconnect();
			Debug.Log("Server is playing");
            this.WarningDialog.Open("Alert!", "This room are playing now..." + Environment.NewLine + "Why you don't ask your friends");
        }
    }

}
