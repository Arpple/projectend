using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace End.Game.UI {
    public class Icon :MonoBehaviour {
        public Image IconImage;
        public Image BorderImage;

        public void SetImage(Sprite sprite) {
            this.IconImage.sprite = sprite;
        }

        public void SetBorderColor(Color col) {
            var color = BorderImage.color;
            color = col;
            BorderImage.color = color;
        }
    }
}
