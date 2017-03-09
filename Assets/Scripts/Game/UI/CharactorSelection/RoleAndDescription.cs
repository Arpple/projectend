using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace End.Game.UI.CharactorSelection {
    public class RoleAndDescription : MonoBehaviour{
        public Text RoleName, RoleDescription;
        public const string GOD_DESCRIPTION="Beat the Aspotle and All Atheist"
            ,ASPOTEL_DESCRIPTION = "Beat God. After that Beat All Atheist"
            , PRIEST_DESCRIPTION = "Win with God or Aspotle"
            , ATHEIST_DESCRIPTION = "Beat God and Aspotle";

        public void ShowGodDetail() {
            this.RoleName.text = "God";
            this.RoleDescription.text = GOD_DESCRIPTION;
            //return GOD_DESCRIPTION;
        }

        public void ShowAspotleDetail() {
            this.RoleName.text = "Aspotle";
            this.RoleDescription.text = ASPOTEL_DESCRIPTION;
            //return ASPOTEL_DESCRIPTION;
        }
        
        public void ShowPriestDetail() {
            this.RoleName.text = "Priest";
            this.RoleDescription.text = PRIEST_DESCRIPTION;
            //return PRIEST_DESCRIPTION;
        }

        public void ShowAtheistDetail() {
            this.RoleName.text = "Atheist";
            this.RoleDescription.text = ATHEIST_DESCRIPTION;
           // return ATHEIST_DESCRIPTION;
        }
    }
}
