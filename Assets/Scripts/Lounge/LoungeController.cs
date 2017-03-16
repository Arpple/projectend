﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using End.UI;
using UnityEngine.Networking;

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
			ToggleButton(true);
			ConnectionDialogue.OnBackButton += () => ToggleButton(true);
			ConnectionDialogue.OnJoinButton += () =>
			{
				ToggleButton(true);

				Connect(false);
			};

			NetCon.OnClientErrorCallback += ConnectError;
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
				NetCon.StartHost();
			}
			else
			{
				var ip = ConnectionDialogue.IpAddress;
				Debug.Log("Connecting to " + ip);
				NetCon.networkAddress = ip;
				NetCon.StartClient();

				//TODO: show connecting dialogue
			}
		}

		public void ConnectError(int errorCode)
		{
			if(errorCode == (int)NetworkError.Timeout)
			{
				//TODO: show warining / erorr
				Debug.Log("Time Out");
			}
		}
	}

}
