using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using End.UI;

namespace End.Lobby.UI
{
	public class LobbyPlayer : NetworkLobbyPlayer
	{
		public delegate void PlayerStatusChangeAction(bool isReady);

		readonly Color Color_Yellow = new Color(1, 237f / 255, 0);
		readonly Color Color_Orange = new Color(1, 143 / 255f, 0);
		readonly Color Color_Green = new Color(36f / 255, 1, 46f / 255);

		[Header("Config")]
		public Text PlayerNameText;
		public Text PlayerStatusText;
		public Icon PlayerIcon;

		[SyncVar(hook = "OnNameChanged")]
		public string PlayerName;

		[SyncVar(hook = "OnReadyChanged")]
		public bool IsReady;

		[SyncVar(hook = "OnIconChanged")]
		public string PlayerIconPath;

		public PlayerStatusChangeAction StatusChangeCallback;

		#region Local
		public void OnNameChanged(string newName)
		{
			PlayerName = newName;
			PlayerNameText.text = newName;
		}

		public void OnReadyChanged(bool isReady)
		{
			IsReady = isReady;
			PlayerStatusText.text = isReady ? "Ready" : "Waiting";

			//change status to ready
			if(isReady)
			{
				PlayerStatusText.color = Color_Green;
			}

			if (StatusChangeCallback != null) StatusChangeCallback(IsReady);
		}

		public void OnIconChanged(string newIconPath)
		{
			PlayerIconPath = newIconPath;
			PlayerIcon.SetImage(Resources.Load<Sprite>(newIconPath));
		}

		private void Update()
		{
			if(!IsReady)
			{
				PlayerStatusText.color = Color.Lerp(Color_Yellow, Color_Orange, Mathf.PingPong(Time.time, 2f));
			}
		}

		public void OnDestroy()
		{
			LobbyController.Instance.RemovePlayer();
		}
		#endregion

		#region Network
		public override void OnClientEnterLobby()
		{
			base.OnClientEnterLobby();

			LobbyController.Instance.AddPlayer(this);
		}

		public override void OnStartAuthority()
		{
			base.OnStartAuthority();

			LobbyController.Instance.SetupLocalPlayer(this);
		}

		public override void OnClientReady(bool readyState)
		{
			base.OnClientReady(readyState);
			IsReady = true;
		}

		[Command]
		public void CmdSetName(string name)
		{
			PlayerName = name;
		}

		[Command]
		public void CmdSetStatus(bool isReady)
		{
			IsReady = isReady;
		}
		#endregion
	}

}
