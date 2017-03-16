using UnityEngine;
using UnityEngine.Networking;

namespace End
{
	public class Player : NetworkBehaviour
	{
		public const int MAX_PLAYER = 8;

		public static int PlayerCount;

		[SyncVar] public short PlayerId;

		[SyncVar(hook = "OnNameChanged")]
		public string PlayerName;

		[SyncVar(hook = "OnIconPathChanged")]
		public string PlayerIconPath;

		[SyncVar(hook = "OnCharacterIdChanged")]
		public int SelectedCharacterId;

		[SyncVar(hook = "OnReadyStateChanged")]
		public bool IsReady;

		public delegate void ChangeNameCallback(string name);
		public delegate void ChangeIconPathCallback(string iconPath);
		public delegate void ChangeSelectedCharacterCallback(int charId);
		public delegate void ChangeReadyStateCallback(bool ready);

		public event ChangeNameCallback OnNameChangedCallback;
		public event ChangeIconPathCallback OnIconPathChangedCallback;
		public event ChangeSelectedCharacterCallback OnSelectedCharacterChangedCallback;
		public event ChangeReadyStateCallback OnReadyStateChangedCallback;

		public void OnNameChanged(string name)
		{
			PlayerName = name;
			if (OnNameChangedCallback != null) OnNameChangedCallback(name);
		}

		public void OnIconPathChanged(string iconPath)
		{
			PlayerIconPath = iconPath;
			if (OnIconPathChangedCallback != null) OnIconPathChangedCallback(iconPath);
		}

		public void OnCharacterIdChanged(int charId)
		{
			SelectedCharacterId = charId;
			if (OnSelectedCharacterChangedCallback != null) OnSelectedCharacterChangedCallback(charId);
		}

		public void OnReadyStateChanged(bool ready)
		{
			IsReady = ready;
			if (OnReadyStateChangedCallback != null) OnReadyStateChangedCallback(ready);
		}

		#region Network
		public override void OnStartLocalPlayer()
		{
			base.OnStartLocalPlayer();

			var netCon = NetworkController.Instance;
			CmdSetName(netCon.LocalPlayerName);
			CmdSetIconPath(netCon.LocalPlayerIconPath);

			Lobby.LobbyController lobby = Lobby.LobbyController.Instance;
			lobby.SetLocalPlayer(this);
		}

		public override void OnStartClient()
		{
			base.OnStartClient();

			Lobby.LobbyController.Instance.AddPlayer(this);
		}

		[Command]
		public void CmdSetName(string name)
		{
			PlayerName = name;
		}

		[Command]
		public void CmdSetIconPath(string iconPath)
		{
			PlayerIconPath = iconPath;
		}

		[Command]
		public void CmdSetCharacterId(int charId)
		{
			SelectedCharacterId = charId;
		}

		[Command]
		public void CmdSetReadyStatus(bool ready)
		{
			IsReady = ready;
		}
		#endregion
	}

}
