using End.UI.CustomButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace End.UI.Dialogue {
    public class DialogueManager : MonoBehaviour{

        public Dialogue DefaultDialog;
        public GameObject BackgroundPanel;

        public static DialogueManager Instance;
        private static Canvas DialogueCanvas;
        private static Stack<Dialogue> dialogues = new Stack<Dialogue>();
        

        void Awake() {
            DialogueManager.Instance = this;
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
            dialogues.Push(dialog);
            dialog.gameObject.SetActive(true);
            dialog.transform.SetParent(Instance.BackgroundPanel.transform);
            if(dialogues.Count > 0) {
                Instance.BackgroundPanel.SetActive(true);
            }
        }

        /// <summary>
        /// Close Dialog and remove from navigator(stack).
        /// </summary>
        /// <param name="dialog"></param>
        /// <returns>result of close successful</returns>
        public static bool CloseDialogue(Dialogue dialog) {
            bool result = false;
            if(dialogues.Peek() == dialog) {
                dialogues.Pop();
                result = true;
            }
            if(dialogues.Count <= 0) {
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
