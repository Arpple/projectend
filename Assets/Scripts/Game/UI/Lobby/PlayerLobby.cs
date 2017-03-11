using End.Game.UI;
using UnityEngine;
using UnityEngine.UI;

namespace End.Lobby.UI {
    public class PlayerLobby: MonoBehaviour {
        public enum PlayerStatus {
            Waiting,Ready
        }
        public Icon PlayerIcon;
        public Text PlayerName,PlayerStat;
        public PlayerStatus Status;
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
            ChangeTextColorByStatus();   
        }

        private void ChangeTextColorByStatus() {
            PlayerStatus status = this.Status;
            var color = this.PlayerStat.color;
            switch(status) {
                case PlayerStatus.Waiting:
                color = Color.Lerp(Color_Yellow,Color_Orange, Mathf.PingPong(Time.time, 2f));
                break;
                default:
                color = Color_Green;
                break;
            }
            this.PlayerStat.color = color;
            this.PlayerStat.text = status.ToString();
        }

        public void SetPlayerStatus(PlayerStatus status) {
            this.Status = status;
            this.PlayerStat.text = status.ToString();
        }

        /// <summary>
        /// Is dummy parameter fix after got playerNetwork
        /// </summary>
        /// <param name="name"></param>
        /// <param name="spritePath"></param>
        public void SetPlayerData(string name,string spritePath= "Unit/Character/LastBoss/Icon",PlayerStatus stat=PlayerStatus.Waiting) {
            this.PlayerName.text = name;
            this.PlayerIcon.SetImage(Resources.Load<Sprite>("Unit/Character/LastBoss/Icon"));
            SetPlayerStatus(stat);
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