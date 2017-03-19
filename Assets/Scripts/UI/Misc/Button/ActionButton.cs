using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace End.UI.CustomButton{
    public class ActionButton {

        public string ButtonDescripion;
        public Sprite ButtonSprite;
        public ClickAction action;
        public delegate void ClickAction();

        public ActionButton(ClickAction action, string description) {
            this.action = action;
            this.ButtonDescripion = description;
        }

        public void setButton(ClickAction action,string description,Sprite sprite) {
            this.action = action;
            this.ButtonDescripion = description;
            this.ButtonSprite = sprite;
        }
    }
}
