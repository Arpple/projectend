using UnityEngine;

namespace End.Lobby.UI {
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

        /// <summary>
        /// Click to change your stat to ready
        /// </summary>
        public void Ready() {

        }

        /// <summary>
        /// Click to Change your stat to Waiting
        /// </summary>
        public void Waiting() {

        }
    }
}
