using End.Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace End.UI.Lobby {
    public class PlayerLobby: MonoBehaviour {
        public enum PlayerStaus {
            Waiting,Ready
        }
        public Icon PlayerIcon;
        public Text PlayerName,PlayerStatus;
        public PlayerStaus Status;
        public bool onAllocate;

        public Color Color_Yellow {
            get {
                Color c = new Color(1, 237f / 255, 0);
                return c;
            }
        }

        public Color Color_Orange {
            get {
                Color c = new Color(1, 143 / 255f, 0);
                return c;
            }
        }

        public Color Color_Green {
            get {
                Color c= new Color(36f / 255, 1, 46f / 255);
                return c;
            }
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            DummyChangeTextStatus();   
        }

        private void DummyChangeTextStatus() {
            PlayerStaus status = this.Status;
            var color = this.PlayerStatus.color;
            switch(status) {
                case PlayerStaus.Waiting:
                color = Color.Lerp(Color_Yellow,Color_Orange, Mathf.PingPong(Time.time, 2f));
                break;
                default:
                color = Color_Green;
                break;
            }
            this.PlayerStatus.color = color;

            this.PlayerStatus.text = status.ToString();
        }

        public void SetPlayerStatus(PlayerStaus status) {
            this.Status = status;
        }

        /// <summary>
        /// Is dummy parameter fix after got playerNetwork
        /// </summary>
        /// <param name="name"></param>
        /// <param name=""></param>
        public void SetPlayerData(string name) {
            this.PlayerName.text = name;
            //this.PlayerIcon.sprite = Resources.Load<Sprite>("Unit/Character/LastBoss/Icon");
            this.PlayerIcon.SetImage(Resources.Load<Sprite>("Unit/Character/LastBoss/Icon"));
            onAllocate = true;
        }

        /// <summary>
        /// Is dummy Parameter too
        /// </summary>
        public void RemovePlayerData() {
            this.PlayerName.text = "<NO PLAYER>";
            this.PlayerIcon.SetImage(null);
            this.onAllocate = false;
        }
    }
}