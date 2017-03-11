using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace End.UI.Lobby {
    public class LobbyBodyController : MonoBehaviour{
        #region Global set Variable
        public PlayerLobby PrefabsPlayerLobbyLeft, PrefabsPlayerLobbyRight;
        public GameObject PrefabsPlayerRow;
        public GameObject Content;
        #endregion
        
        private List<PlayerLobby> _playerLobbyList;
        private List<GameObject> _playerLobbyRowList;

        void Awake() {
            this._playerLobbyList = new List<PlayerLobby>();
            this._playerLobbyRowList = new List<GameObject>();
            
        }

        void Start() {
            PrepareLobby();
        }

        void Update() {

        }

        #region Setting Scence Method
        private void PrepareLobby() {
            for(int i = 1; i <= 4; i++) {
                //Debug.Log("Spanw row ["+i+"] row pref is null ? "+(PrefabsPlayerRow==null));
                GameObject row = SpawnPlayerLobbyRow();
                for(int j = 1; j <= 2; j++) {
                    SpawnPlayerLobby(row.transform);
                }
            }
        }

        /// <summary>
        /// Spanw player lobby row and save it in list(memories)
        /// </summary>
        /// <returns></returns>
        private GameObject SpawnPlayerLobbyRow() {
            //Debug.Log("PrefabsPlayerRow is null ? "+(PrefabsPlayerRow==null)+" at round [ "+this._playerLobbyRowList.Count+" ]");
            GameObject row = Instantiate(this.PrefabsPlayerRow, this.Content.transform, false);
            row.transform.SetParent(this.Content.transform);
            row.gameObject.SetActive(true);
            this._playerLobbyRowList.Add(row);
            return row;
        }

        /// <summary>
        /// Spanw plyer lobby and save it in list(memories)
        /// </summary>
        /// <returns></returns>
        private PlayerLobby SpawnPlayerLobby(Transform parent = null) {
            Transform trans = parent.transform;
            PlayerLobby p = Instantiate<PlayerLobby>(
                _playerLobbyList.Count % 2 == 0 ? PrefabsPlayerLobbyLeft : PrefabsPlayerLobbyRight
                , trans, false
                );
            this._playerLobbyList.Add(p);
            p.RemovePlayerData();
            p.gameObject.SetActive(true);
            return p;
        }
        #endregion
        

        /// <summary>
        /// Add player to show in content on a free slot(not Allocate)
        /// </summary>
        public void AddPlayer() {
            foreach(PlayerLobby p in _playerLobbyList) {
                if(!p.onAllocate) {
                    //TODO : use this
                    p.SetPlayerData("Random ["+_playerLobbyList.IndexOf(p)+"]","",PlayerLobby.PlayerStatus.Waiting);
                    break;
                }
            }
        }
        
        /// <summary>
        /// Remove Player from the content (hide)
        /// </summary>
        /// <param name="index"></param>
        public void RemovePlayer(int index) {
            foreach(PlayerLobby p in _playerLobbyList) {
                //TODO : find player in _lobbyList and disable this :|
                if(_playerLobbyList.IndexOf(p)==index) {
                    p.RemovePlayerData();
                }
            }
        }

        
    }
}
