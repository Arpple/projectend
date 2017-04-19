using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace Network
{
	public class Player : NetworkBehaviour, IPlayer
	{
		[SyncVar] public int PlayerId;

		#region SyncProperties
		[SyncVar(hook = "OnNameChanged")]
		public string PlayerName;

		[SyncVar(hook = "OnIconChanged")]
		public int PlayerIconId;

		[SyncVar(hook = "OnCharacterIdChanged")]
		public int SelectedCharacterId;

		[SyncVar(hook = "OnReadyStateChanged")]
		public bool IsReady;

		[SyncVar(hook = "OnMainMissionChanged")]
		public int MainMissionId;

		[SyncVar]
		public int SubMissionId;

		[SyncVar(hook = "OnRoundLimitChanged")]
		public int RoundLimit;

		public delegate void ChangeNameCallback(string name);
		public delegate void ChangeIconCallback(int iconId);
		public delegate void ChangeSelectedCharacterCallback(int charId);
		public delegate void ChangeReadyStateCallback(bool ready);

		public event ChangeNameCallback OnNameChangedCallback;
		public event ChangeIconCallback OnIconChangedCallback;
		public event ChangeSelectedCharacterCallback OnSelectedCharacterChangedCallback;
		public event ChangeReadyStateCallback OnReadyStateChangedCallback;

		public UnityAction<MainMission> OnMainMissionChangedCallback;
		public UnityAction<int> OnRoundLimitChangedCallback;

		public delegate void PlayerDisconnectCallback();
		public event PlayerDisconnectCallback OnPlayerDisconnectCallback;

		public void OnNameChanged(string name)
		{
			PlayerName = name;
			if (OnNameChangedCallback != null) OnNameChangedCallback(name);
		}

		public void OnIconChanged(int iconId)
		{
			PlayerIconId = iconId;
			if (OnIconChangedCallback != null) OnIconChangedCallback(iconId);
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

			if (isServer)
			{
				if (NetworkController.Instance.AllPlayers.TrueForAll(p => p.IsReady)) { NetworkController.Instance.OnServerAllPlayerReady(); }
			}
		}

		public void OnMainMissionChanged(int mainMissionId)
		{
			MainMissionId = mainMissionId;
			if (OnMainMissionChangedCallback != null)
				OnMainMissionChangedCallback((MainMission)mainMissionId);
		}

		public void OnRoundLimitChanged(int round)
		{
			RoundLimit = round;
			if (OnRoundLimitChangedCallback != null)
			{
				OnRoundLimitChangedCallback(round);
			}
		}
		#endregion

		private void Start()
		{
			CrossSceneObject.AddObject(gameObject);
		}

		private void OnDestroy()
		{
			if (OnPlayerDisconnectCallback != null) OnPlayerDisconnectCallback();

			if (NetworkController.Instance != null)
				NetworkController.Instance.OnDisconnectPlayer(this);
		}

		#region Client
		/// <summary>
		/// Called when the local player object has been set up.
		/// </summary>
		public override void OnStartLocalPlayer()
		{
			base.OnStartLocalPlayer();

			NetworkController.Instance.OnStartLocalPlayer(this);
		}

		/// <summary>
		/// Called on every NetworkBehaviour when it is activated on a client.
		/// </summary>
		public override void OnStartClient()
		{
			base.OnStartClient();

			NetworkController.Instance.OnStartClientPlayer(this);
		}
		#endregion

		#region Server
		private static List<int> _selectedCharacterIdList;
		private static short _playerIdCounter;

		public static void ServerSetup()
		{
			_selectedCharacterIdList = new List<int>();
			_playerIdCounter = 1;
		}

		public override void OnStartServer()
		{
			base.OnStartServer();
			PlayerId = _playerIdCounter;
			_playerIdCounter++;
		}


		#endregion

		#region Command
		[Command]
		public void CmdSetName(string name)
		{
			PlayerName = name;
		}

		[Command]
		public void CmdSetIcon(int iconId)
		{
			PlayerIconId = iconId;
		}

		[Command]
		public void CmdSetCharacterId(int charId)
		{
			if (!_selectedCharacterIdList.Contains(charId) && charId != (int)Character.None)
			{
				_selectedCharacterIdList.Add(charId);
				SelectedCharacterId = charId;
			}
		}

		[Command]
		public void CmdSetReadyStatus(bool ready)
		{
			IsReady = ready;
		}

		[Command]
		public void CmdCreateEvent(int componentId, params int[] args)
		{
			RpcCreateEvent(componentId, args);
		}

		[Command]
		public void CmdSetRound(int round)
		{
			foreach (var p in NetworkController.Instance.AllPlayers)
			{
				p.RoundLimit = round;
			}
		}

		[Command]
		public void CmdSetMainMission(int missionId)
		{
			foreach(var p in NetworkController.Instance.AllPlayers)
			{
				p.MainMissionId = missionId;
			}
		}

		[ClientRpc]
		public void RpcCreateEvent(int componentId, params int[] args)
		{
			GameEvent.CreateEventEntityAndDecode(componentId, args);
		}

		[ClientRpc]
		public void RpcResetReadyStatus()
		{
			IsReady = false;
		}

		[Command]
		public void CmdClientLoad()
		{
			GameController.Instance.ServerLoadPlayer();
		}

		[ClientRpc]
		public void RpcServerReady()
		{
			GameController.Instance.SetClientReady();
		}
		#endregion

		public int GetId()
		{
			return PlayerId;
		}

		public string GetName()
		{
			return PlayerName;
		}
	}
}
