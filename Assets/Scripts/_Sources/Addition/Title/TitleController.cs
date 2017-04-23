using System;
using Entitas.VisualDebugging.Unity;
using Network;
using UI;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;
using UnityEngine.UI;
using Zenject;

namespace Title
{
	public class TitleController : MonoBehaviour
	{
		public Icon PlayerIcon;
		public InputField PlayerNameInputField;
		public Button HostButton;
		public Button JoinButton;
		public Text VersionText;
		public ConnectionDialogue ConnectionDialogue;
		public Dialogue WarningDialog, ConnectingDialog;
		public PlayerIconSelector IconSelector;

		public NetworkController NetCon
		{
			get { return NetworkController.Instance; }
		}

		private Setting _setting;
		private LocalData _data;

		[Inject]
		public void Construct(Setting setting, LocalData data)
		{
			_setting = setting;
			_data = data;
		}

		private void Awake()
		{
			Assert.IsNotNull(PlayerIcon);
			Assert.IsNotNull(PlayerNameInputField);
			Assert.IsNotNull(HostButton);
			Assert.IsNotNull(JoinButton);
			Assert.IsNotNull(VersionText);
			Assert.IsNotNull(ConnectionDialogue);
			Assert.IsNotNull(WarningDialog);
			Assert.IsNotNull(ConnectingDialog);
		}

		private void Start()
		{
			VersionText.text = "Version " + Application.version;

			//clear old observer
			foreach (var observer in FindObjectsOfType<ContextObserverBehaviour>())
			{
				Destroy(observer.gameObject);
			}

			//set profile
			var playerIconImage = _setting.PlayerIconSetting.GetData(_data.PlayerIcon).Icon;
			if (playerIconImage != null) PlayerIcon.SetImage(playerIconImage);
			PlayerNameInputField.text = _data.PlayerName;
			PlayerNameInputField.onEndEdit.AddListener((s) => _data.PlayerName = PlayerNameInputField.text);

			//set dialogue event
			SetMenuButtonVisible(true);
			ConnectionDialogue.OnBackButton += () => SetMenuButtonVisible(true);
			ConnectionDialogue.OnJoinButton += () =>
			{
				SetMenuButtonVisible(true);

				Connect(false);
			};

			WarningDialog.OnDialogueClose += () => SetMenuButtonVisible(true);
			ConnectingDialog.OnDialogueClose += () => SetMenuButtonVisible(true);

			CreatePlayerIconForSelector();
		}

		private void CreatePlayerIconForSelector()
		{
			foreach (var iconData in _setting.PlayerIconSetting.DataList)
			{
				IconSelector.AddIcon(iconData);
			}
		}

		public void Host()
		{
			Connect(true);
		}

		public void Join()
		{
			ConnectionDialogue.gameObject.SetActive(true);
			SetMenuButtonVisible(false);
		}

		/// <summary>
		/// Toggles button interactable.
		/// </summary>
		/// <param name="isEnable">if set to <c>true</c> [is enable].</param>
		private void SetMenuButtonVisible(bool isEnable)
		{
			JoinButton.interactable = isEnable;
			HostButton.interactable = isEnable;
		}

		private void Connect(bool isHost)
		{
			ShowConnectingDialog();
			SetMenuButtonVisible(false);
			if (isHost)
			{
				Debug.Log("Starting Host");
				if (NetCon.StartHost() == null)
				{
					ShowHostError();
				}
			}
			else
			{
				var ip = ConnectionDialogue.IpAddress;
				Debug.Log("Connecting to " + ip);
				NetCon.networkAddress = ip;
				var client = NetCon.StartClient();
				client.RegisterHandler(NetMessage.MsgServerFull, ServerFullHandler);
				client.RegisterHandler(NetMessage.MsgGameStarted, ServerIsPlayingHandler);
				client.RegisterHandler(MsgType.Disconnect, OnDisconnected);
			}
		}

		private void ShowConnectingDialog()
		{
			ConnectingDialog.Open();
			ConnectingDialog.OnDialogueClose = NetCon.Stop;
		}

		private void OnDisconnected(NetworkMessage netMsg)
		{
			Debug.Log("Connection Error");
			WarningDialog.Open("Alert!", "Disconnected from Host");
			WarningDialog.OnDialogueClose = ConnectingDialog.Close;
		}

		private void ShowHostError()
		{
			WarningDialog.Open("Alert!", "Cannot start server");
			WarningDialog.OnDialogueClose = ConnectingDialog.Close;
		}

		private void ServerFullHandler(NetworkMessage msg)
		{
			msg.conn.Disconnect();
			Debug.Log("Server is full");
			WarningDialog.Open("Alert!", "Hey ! Server is full !" + Environment.NewLine + "Go other room");
		}

		private void ServerIsPlayingHandler(NetworkMessage msg)
		{
			msg.conn.Disconnect();
			Debug.Log("Server is playing");
			WarningDialog.Open("Alert!", "This room are playing now..." + Environment.NewLine + "Why you don't ask your friends");
		}
	}

}
