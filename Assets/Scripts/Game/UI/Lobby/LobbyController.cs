using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace End.UI.Lobby {
    public class LobbyController : MonoBehaviour{
        public LobbyBodyController LobbyBodyController;
        public void AddPlayer() {
            Debug.Log("AddPlayer");
            LobbyBodyController.AddPlayer();
        }

        public void RemovePlayer() {
            int ran = UnityEngine.Random.Range(0, 7);
            Debug.Log("Lobby Controller try to Random remove player ["+ran+"]");
            LobbyBodyController.RemovePlayer(ran);
        }
    }
}
