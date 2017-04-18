using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Title {
    public class ChangeIconDialogue : MonoBehaviour {

        public Image PlayerIcon;
        public Sprite SelectedIconSprite;

        [Header("Icon List")]
        public GameObject IconContent;

        void Awake() {
            Assert.IsNotNull(IconContent);
        }

        public void SelectButton(Button b) {
            foreach(Image icon in IconContent.transform.GetComponentsInChildren<Image>()) {
                if(icon.name.Equals("border")) {
                    icon.color = new Color(0f,0f,0f);
                }
            }
            b.transform.FindChild("border").GetComponent<Image>().color = new Color(1f,206/255f,0f);
            this.SelectedIconSprite = b.transform.FindChild("Icon").GetComponent<Image>().sprite;
            PlayerIcon.overrideSprite = this.SelectedIconSprite;
        }
    }
}
