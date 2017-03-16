using UnityEngine.Networking;

namespace End.Network
{
	public class Player : NetworkBehaviour
	{
		public const int MAX_PLAYER = 8;

		public static int PlayerCount;

		[SyncVar] public short PlayerId;
		[SyncVar(hook = "OnNameChanged")] public string PlayerName;
		[SyncVar(hook = "OnIconPathChanged")] public string PlayerIconPath;
		[SyncVar(hook = "OnCharacterIdChanged")] public int SelectedCharacterId;

		public delegate void ChangeNameCallback(string name);
		public delegate void ChangeIconPathCallback(string iconPath);
		public delegate void ChangeSelectedCharacterCallback(int charId);

		public event ChangeNameCallback OnNameChangedCallback;
		public event ChangeIconPathCallback OnIconPathChangedCallback;
		public event ChangeSelectedCharacterCallback OnSelectedCharacterChangedCallback;

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

		#region Network
		public override void OnStartLocalPlayer()
		{
			base.OnStartLocalPlayer();

			var netCon = NetworkController.Instance;
			CmdSetName(netCon.LocalPlayerName);
			CmdSetIconPath(netCon.LocalPlayerIconPath);
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

		#endregion
	}

}
