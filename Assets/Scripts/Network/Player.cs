using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

namespace End
{
    public class Player : NetworkBehaviour
    {
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

        public delegate void PlayerDisconnectCallback();
        public event PlayerDisconnectCallback OnPlayerDisconnectCallback;

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

            if (isServer)
            {
                if (AllPlayers.TrueForAll(p => p.IsReady)) { NetworkController.Instance.OnServerAllPlayerReady(); }
            }
        }
        #endregion

        private void Awake()
        {
            //DontDestroyOnLoad(gameObject);
        }

        private void OnDestroy()
        {
            if (isServer)
            {
                Assert.IsNotNull(AllPlayers);
                AllPlayers.Remove(this);
            }

            if (OnPlayerDisconnectCallback != null) OnPlayerDisconnectCallback();
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
        public static List<Player> AllPlayers;
        private static List<int> _selectedCharacterIdList;

        public static void ServerSetup()
        {
            AllPlayers = new List<Player>();
            _selectedCharacterIdList = new List<int>();
        }

        public override void OnStartServer()
        {
            base.OnStartServer();

            Assert.IsNotNull(AllPlayers);
            AllPlayers.Add(this);
        }


        #endregion

        #region Command
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
            if (!_selectedCharacterIdList.Contains(charId) && charId != (int)Game.Character.None)
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

        [ClientRpc]
		public void RpcCreateEvent(int componentId, params int[] args)
		{
			Game.GameEventHelper.CreateEventAndDecode(componentId, args);
		}

		#endregion
	}

}
