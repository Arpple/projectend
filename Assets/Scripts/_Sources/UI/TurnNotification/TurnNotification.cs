using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UI {
    public class TurnNotification: MonoBehaviour {
        public Text Turn, Player;
        public Animator AnimaControl;

        public void Show(string turn, string playerName) {
            this.Turn.text = "Turn " + turn;
            this.Player.text = playerName;
            Play();
        }

        public void Play() {
            AnimaControl.Play("Show");
        }
    }
}