using System;
using UnityEngine;
using UnityEngine.UI;

namespace End.CharacterSelect {
    public class RoleAndDescription : MonoBehaviour{
        public Text RoleName, RoleDescription;

        public static readonly string GOD_NAME = "God"
            ,APOSTLE_NAME = "Apostle"
            ,PRIEST_NAME = "Priest"
            ,ATHEIST_NAME = "Atheist"
            ;

        public const string GOD_DESCRIPTION="Beat the Aspotle and All Atheist"
            ,APOSTLE_DESCRIPTION = "Beat God. After that Beat All Atheist"
            , PRIEST_DESCRIPTION = "Win with God or Aspotle"
            , ATHEIST_DESCRIPTION = "Beat God and Aspotle";

        public static readonly string GOD_WIN_CONDITION = "1.Defeat Apostle" + Environment.NewLine
                + "2.Defeat all Atheist" + Environment.NewLine
                + "3.Don't died..."
            , APOSTLE_WIN_CONDITION = "1.Defeat God" + Environment.NewLine
                + "2.Defeat all Atheist" + Environment.NewLine
                + "3.Don't died..."
            , PRIEST_WIN_CONDITION = "1.Help God or Apostle" + Environment.NewLine
                + "2.Defeat all Atheist" + Environment.NewLine
                + "3.Win with God or Apostle"
            , ATHEIST_WIN_CONDITION = "1.Defeat God" + Environment.NewLine
                + "2.Defeat Atheist" + Environment.NewLine
                + "3.Win with other Atheist";

        public static readonly string ICON_PATH_GOD = "Game/Role/_Sprite/[Role]Icon_God"
            , ICON_PATH_APOSTLE = "Game/Role/_Sprite/[Role]Icon_Apostle"
            , ICON_PATH_PRIEST = "Game/Role/_Sprite/[Role]Icon_Priest"
            , ICON_PATH_ATHEIST = "Game/Role/_Sprite/[Role]Icon_Atheist";

        public void ShowGodDetail() {
            this.RoleName.text = "God";
            this.RoleDescription.text = GOD_DESCRIPTION;
        }

        public void ShowAspotleDetail() {
            this.RoleName.text = "Aspotle";
            this.RoleDescription.text = APOSTLE_DESCRIPTION;
        }
        
        public void ShowPriestDetail() {
            this.RoleName.text = "Priest";
            this.RoleDescription.text = PRIEST_DESCRIPTION;
        }

        public void ShowAtheistDetail() {
            this.RoleName.text = "Atheist";
            this.RoleDescription.text = ATHEIST_DESCRIPTION;
        }
    }
}
