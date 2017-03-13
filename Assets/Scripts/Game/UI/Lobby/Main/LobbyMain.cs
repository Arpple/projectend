using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Lobby.UI
{
	public class LobbyMain : MonoBehaviour
	{
		public GameObject PlayerContainer;
		public Button ReadyButton;
		public Button WaitButton;

		private void Awake()
		{
			Assert.IsNotNull(PlayerContainer);
			Assert.IsNotNull(ReadyButton);
			Assert.IsNotNull(WaitButton);
		}

		public void AddPlayer(LobbyPlayer player)
		{
			player.transform.SetParent(PlayerContainer.transform, false);
		}

		public void SetupLocalPlayer(LobbyPlayer player)
		{
			ReadyButton.onClick.RemoveAllListeners();
			ReadyButton.onClick.AddListener(() => player.SendReadyToBeginMessage());

			WaitButton.onClick.RemoveAllListeners();
			WaitButton.onClick.AddListener(() => player.SendNotReadyToBeginMessage());

			player.StatusChangeCallback = OnPlayerStatusChange;
		}

		public void OnPlayerStatusChange(bool isReady)
		{
			if(isReady)
			{
				ReadyButton.gameObject.SetActive(false);
				WaitButton.gameObject.SetActive(true);
			}
			else
			{
				ReadyButton.gameObject.SetActive(true);
				WaitButton.gameObject.SetActive(false);
			}
		}
	}
}
