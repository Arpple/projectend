using End.UI;
using UnityEngine;
using UnityEngine.UI;
namespace End.Game.CharacterSelect {
    public class FocusPlayerStatus : MonoBehaviour{

        readonly Color Color_Yellow = new Color(1, 237f / 255, 0);
        readonly Color Color_Orange = new Color(1, 143 / 255f, 0);
        readonly Color Color_Green = new Color(36f / 255, 1, 46f / 255);

        public static FocusPlayerStatus Instance;
        public Text PlayerName, PlayerLockedStatus, PlayerRole;
        public Icon CharacterSelectedIcon;

        void Awake() {
            Instance = this;
            this.gameObject.SetActive(false);
        }

        public void SetFocusPlayer(string playerName,bool isLocked, string playerRole, Sprite characterSelectedIcon) {
            PlayerName.text = playerName;
            PlayerLockedStatus.text = isLocked ? ("-Locked-") : "-Waiting-";
            if(isLocked) {
                PlayerLockedStatus.color = Color_Green;
            } else {
                PlayerLockedStatus.color = Color.Lerp(Color_Yellow, Color_Orange, Mathf.PingPong(Time.time, 2f));
            }

            PlayerRole.text = playerRole;
            CharacterSelectedIcon.SetImage(characterSelectedIcon);
            this.gameObject.SetActive(true);
        }
    }
}
