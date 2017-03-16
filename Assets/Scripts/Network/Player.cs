using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

namespace End
{
	public class Player : NetworkBehaviour
	{
		public static List<Player> AllPlayers;

		[SyncVar] public short PlayerId;

		#region SyncProperties
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

			if(isServer)
			{
				if(AllPlayers.TrueForAll(p => p.IsReady)) { NetworkController.Instance.OnServerAllPlayerReady(); }
			}
		}
		#endregion

		private void Start()
		{
			Assert.IsNotNull(AllPlayers);

			AllPlayers.Add(this);
		}

		private void OnDestroy()
		{
			Assert.IsNotNull(AllPlayers);

			AllPlayers.Remove(this);
		}

		#region Network		
		/// <summary>
		/// Called when the local player object has been set up.
		/// </summary>
		public override void OnStartLocalPlayer()
		{
			base.OnStartLocalPlayer();

			var netCon = NetworkController.Instance;
			CmdSetName(netCon.LocalPlayerName);
			CmdSetIconPath(netCon.LocalPlayerIconPath);

			Lobby.LobbyController lobby = Lobby.LobbyController.Instance;
			lobby.SetLocalPlayer(this);
		}

		/// <summary>
		/// Called on every NetworkBehaviour when it is activated on a client.
		/// </summary>
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
