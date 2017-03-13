using UnityEngine;
using UnityEngine.UI;

namespace End.UI {
    public class Icon :MonoBehaviour {
        public Image IconImage;
        public Image BorderImage;

        public void SetImage(Sprite sprite) {
            this.IconImage.sprite = sprite;
        }

        public void SetBorderColor(Color col) {
			BorderImage.color = col;
        }
	}
}
