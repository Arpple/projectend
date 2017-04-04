using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class Dialogue :MonoBehaviour{
        public Text DialogueTopic;
        public Text DialogueText;

		public delegate void CloseDialogueCallback();
		public event CloseDialogueCallback OnDialogueClose;

        public void SetDialogue(string topic,string text) {
            DialogueText.text = text;
            this.DialogueTopic.text = topic;
        }
        
        public virtual void Open() {
            DialogueManager.PopupDialogue(this);
            this.gameObject.SetActive(true);
        }

        public virtual void Open(string topic,string text) {
            SetDialogue(topic, text);
            Open();
        }

        public virtual void Close() {
            if(DialogueManager.CloseDialogue(this)) {
                this.gameObject.SetActive(false);
				if(OnDialogueClose != null) { OnDialogueClose(); }
            }
        }
    }
}
