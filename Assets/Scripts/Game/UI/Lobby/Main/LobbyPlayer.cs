using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using End.UI;

namespace End.Lobby.UI
{
	public class LobbyPlayer : NetworkLobbyPlayer
	{
		public enum Status
		{
			Wait,
			Ready,
		}

		readonly Color Color_Yellow = new Color(1, 237f / 255, 0);
		readonly Color Color_Orange = new Color(1, 143 / 255f, 0);
		readonly Color Color_Green = new Color(36f / 255, 1, 46f / 255);

		[Header("Config")]
		public Text PlayerNameText;
		public Text PlayerStatusText;
		public Icon PlayerIcon;

		[SyncVar(hook = "OnNameChanged")]
		public string PlayerName;

		[SyncVar(hook = "OnStatusChanged")][HideInInspector]
		public int __playerStatus;

		[SyncVar(hook = "OnIconChanged")]
		public string PlayerIconPath;

		public Status PlayerStatus
		{
			get { return (Status)__playerStatus; }
			set { __playerStatus = (int)value; }
		}

		public void OnNameChanged(string newName)
		{
			PlayerName = newName;
			PlayerNameText.text = newName;
		}

		public void OnStatusChanged(int newStatusNumber)
		{
			__playerStatus = newStatusNumber;
			PlayerStatusText.text = PlayerStatus.ToString();

			//change status to ready
			if(PlayerStatus == Status.Ready)
			{
				PlayerStatusText.color = Color_Green;
			}
		}

		public void OnIconChanged(string newIconPath)
		{
			PlayerIconPath = newIconPath;
			PlayerIcon.SetImage(Resources.Load<Sprite>(newIconPath));
		}

		private void Update()
		{
			if(PlayerStatus == Status.Wait)
			{
				PlayerStatusText.color = Color.Lerp(Color_Yellow, Color_Orange, Mathf.PingPong(Time.time, 2f));
			}
		}
	}

}
