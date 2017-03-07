using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace End.UI.Lobby {
    public class LobbyBodyController : MonoBehaviour{
        public PlayerLobby PrefabsPlayerLobbyLeft,PrefabsPlayerLobbyRight;
        public GameObject PrefabsRow,Content;

        private List<PlayerLobby> _playerLobbyList;
        private List<GameObject> _playerLobbyRowList;

        void Awake() {
            this._playerLobbyList = new List<PlayerLobby>();
            this._playerLobbyRowList = new List<GameObject>();
            PrepareLobby();
        }

        void Update() {

        }

        private void PrepareLobby() {
            for(int i=1;i<=4;i++) {
                GameObject row = SpawnPlayerLobbyRow();
                for(int j=1;j<=2;j++) {
                    PlayerLobby p = SpawnPlayerLobby(row.transform);
                }
            }
        }

        /// <summary>
        /// Spanw player lobby row and save it in list(memories)
        /// </summary>
        /// <returns></returns>
        private GameObject SpawnPlayerLobbyRow() {
            GameObject row = Instantiate<GameObject>(PrefabsRow,this.Content.transform,false);
            row.transform.SetParent(this.Content.transform);
            row.SetActive(true);
            this._playerLobbyRowList.Add(row);
            return row;
        }

        /// <summary>
        /// Spanw plyer lobby and save it in list(memories)
        /// </summary>
        /// <returns></returns>
        private PlayerLobby SpawnPlayerLobby(Transform parent=null) {
            PlayerLobby p = Instantiate<PlayerLobby>(
                _playerLobbyList.Count % 2 == 0 ? PrefabsPlayerLobbyLeft : PrefabsPlayerLobbyRight
                ,parent,false
                );
            this._playerLobbyList.Add(p);
            p.RemovePlayerData();
            p.gameObject.SetActive(true);
            return p;
        }

        public void AddPlayer() {
            foreach(PlayerLobby p in _playerLobbyList) {
                if(!p.onAllocate) {
                    //TODO : use this
                    p.SetPlayerData("Random ["+_playerLobbyList.IndexOf(p)+"]");
                    break;
                }
            }
        }
        
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
