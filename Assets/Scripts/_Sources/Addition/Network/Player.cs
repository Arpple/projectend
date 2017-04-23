using System.Collections.Generic;
using System.Linq;
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

		[SyncVar(hook = "OnPlayerMissionChanged")]
		public int PlayerMissionId;
		[SyncVar(hook = "OnPlayerMissionTargetChanged")]
		public int PlayerMissionTarget;

		public bool MainMissionComplete;
		public bool PlayerMissionComplete;

		[SyncVar(hook = "OnRoundLimitChanged")]
		public int RoundLimit;

		public bool IsClientSceneLoaded;

		public UnityAction<string> NameUpdateAction;
		public UnityAction<PlayerIcon> IconUpdateAction;
		public UnityAction<Character> CharacterUdateAction;
		public UnityAction<bool> ReadyStateUpdateAction;
		public UnityAction<MainMission> MainMissionUpdateAction;
		public UnityAction<PlayerMission> PlayerMissionUpdateAction;
		public UnityAction<int> MissionTargetUpdateAction;
		public UnityAction<int> RoundLimitUpdateAction;
		public UnityAction AllPlayerSceneLoadedAction;
		public UnityAction DisconnectCallback;

		public void OnNameChanged(string name)
		{
			PlayerName = name;
			if (NameUpdateAction != null) NameUpdateAction(name);
		}

		public void OnIconChanged(int iconId)
		{
			PlayerIconId = iconId;
			if (IconUpdateAction != null) IconUpdateAction((PlayerIcon)iconId);
		}

		public void OnCharacterIdChanged(int charId)
		{
			SelectedCharacterId = charId;
			if (CharacterUdateAction != null) CharacterUdateAction((Character)charId);
		}

		public void OnReadyStateChanged(bool ready)
		{
			IsReady = ready;
			if (ReadyStateUpdateAction != null) ReadyStateUpdateAction(ready);

			if (isServer)
			{
				if (NetworkController.Instance.AllPlayers.TrueForAll(p => p.IsReady)) { NetworkController.Instance.OnServerAllPlayerReady(); }
			}
		}

		public void OnMainMissionChanged(int mainMissionId)
		{
			MainMissionId = mainMissionId;
			if (MainMissionUpdateAction != null)
				MainMissionUpdateAction((MainMission)mainMissionId);
		}

		public void OnPlayerMissionChanged(int missionId)
		{
			PlayerMissionId = missionId;
			if (PlayerMissionUpdateAction != null)
				PlayerMissionUpdateAction((PlayerMission)missionId);
		}

		public void OnPlayerMissionTargetChanged(int targetId)
		{
			PlayerMissionTarget = targetId;
			if (MissionTargetUpdateAction != null)
				MissionTargetUpdateAction(targetId);
		}

		public void OnRoundLimitChanged(int round)
		{
			RoundLimit = round;
			if (RoundLimitUpdateAction != null)
			{
				RoundLimitUpdateAction(round);
			}
		}
		#endregion

		private void Start()
		{
			CrossSceneObject.AddObject(gameObject);
		}

		private void OnDestroy()
		{
			if (DisconnectCallback != null) DisconnectCallback();

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

		[Command]
		public void CmdSetPersonalMission(int playerId, int missionId, int target)
		{
			var player = NetworkController.Instance.AllPlayers.First(p => p.PlayerId == playerId);
			player.PlayerMissionId = missionId;
			player.PlayerMissionTarget = target;
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
		public void CmdSendMessageSceneLoaded()
		{
			IsClientSceneLoaded = true;
			if(NetworkController.Instance.AllPlayers.TrueForAll(p => p.IsClientSceneLoaded))
			{
				RpcSceneReady();
			}
		}

		[ClientRpc]
		public void RpcSceneReady()
		{
			if (AllPlayerSceneLoadedAction != null)
			{
				AllPlayerSceneLoadedAction();
			}
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
