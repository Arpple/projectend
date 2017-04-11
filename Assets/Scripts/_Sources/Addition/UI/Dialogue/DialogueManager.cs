using System.Collections.Generic;
using UnityEngine;

namespace UI {
    public class DialogueManager : MonoBehaviour{

        public Dialogue DefaultDialog;
        public GameObject BackgroundPanel;

        public static DialogueManager Instance;
        private Stack<Dialogue> dialogues ;
        

        void Awake() {
            DialogueManager.Instance = this;
            this.dialogues = new Stack<Dialogue>();
        }

        void Update() {

        }

        /// <summary>
        /// Make Defualt Dialogue popup
        /// This dialog that show by this method is a default dialogue
        /// </summary>
        /// <param name="topic">topic of dialog</param>
        /// <param name="text">dialog text in body</param>
        public static void PopupDialogue(string topic, string text) {
            Dialogue dialog = SpawnDefaultDialogue();
            if(dialog == null) return;

            dialog.SetDialogue(topic,text);
            PopupDialogue(dialog);
        }

        /// <summary>
        /// popup dialog that u need.
        /// ( this method does not instantiate dialog object for u )
        /// </summary>
        /// <param name="dialog">Dialog Prefabs.</param>
        public static void PopupDialogue(Dialogue dialog) {
            Instance.BackgroundPanel.SetActive(true);
            //Diable current dialog
            if(Instance.dialogues.Count > 0) {
                Instance.dialogues.Peek().gameObject.SetActive(false);
            }
            //add new dialog :3 and show
            Instance.dialogues.Push(dialog);
            dialog.gameObject.SetActive(true);
            dialog.transform.SetParent(Instance.BackgroundPanel.transform,false);
        }

        /// <summary>
        /// Close Dialog and remove from navigator(stack).
        /// </summary>
        /// <param name="dialog"></param>
        /// <returns>result of close successful</returns>
        public static bool CloseDialogue(Dialogue dialog) {
            bool result = false;
            if(Instance.dialogues.Peek() == dialog) {
                //remove old dialog :\
                Instance.dialogues.Pop().gameObject.SetActive(false);
                result = true;
                if(Instance.dialogues.Count > 0){
                    Instance.dialogues.Peek().gameObject.SetActive(true);
                }
            }

            Debug.Log("Close dialog["+dialog.name+"] now have ["+ Instance.dialogues.Count+"]" );
            if(Instance.dialogues.Count <= 0) {
                Instance.BackgroundPanel.SetActive(false);
            }

            return result;
        }
        
        //Start : Test Function.
       private static Dialogue SpawnDefaultDialogue() {
            Dialogue di = Instantiate<Dialogue>(DialogueManager.Instance.DefaultDialog, Instance.transform, false);
            return di;
        }
        
        public void DummmyShowDialogue() {
            DialogueManager.PopupDialogue("Make Dummy ["+dialogues.Count+"]","Do you want to make Dummy dialog?");
        }
        //END : Test Funcion.
    }
}
