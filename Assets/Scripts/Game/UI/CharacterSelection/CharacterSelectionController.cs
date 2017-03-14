﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using End.Game.UI.CharacterSelection;
using UnityEngine.UI;

namespace End.UI.CharacterSelection {
    public class CharacterSelectionController : MonoBehaviour{
        public UnitStatus UnitStatus;
        public UnitSkill UnitSkill;

        public GameObject RoleContent,CharacterContent;

        void Start() {
            InitialPrefabs();
        }

        private void InitialPrefabs() {

        }

        public void SetPlayerInTheGame(List<object> players) {

        }

        /// <summary>
        /// Show Unit Info 
        /// </summary>
        public void ShowUnitInformationUnit(object unit) {
            //TODO : Set Character Status
            //UnitStatus.setCharacterStatus();
            
            //TODO : Set Character Ability
            //UnitSkill.SetAbility();
        }

        #region UI RoleContent

        public Text RoleTitle, RoleDesciption;
        public Image RoleImage;

        public void ToggleViewRole() {
            bool isActive = this.RoleContent.activeInHierarchy;
            this.RoleContent.SetActive(!isActive);
            //this.CharacterContent.SetActive(isActive);
        }

        public void GodRole() {
            RoleTitle.text = "- "+RoleAndDescription.GOD_NAME+" -";
            RoleDesciption.text = "Win Condition"+ Environment.NewLine
                + RoleAndDescription.GOD_WIN_CONDITION;
            RoleImage.sprite = Resources.Load<Sprite>(RoleAndDescription.ICON_PATH_GOD);
        }

        public void ApostleRole() {
            RoleTitle.text = "- " + RoleAndDescription.APOSTLE_NAME + " -";
            RoleDesciption.text = "Win Condition" + Environment.NewLine
                + RoleAndDescription.APOSTLE_WIN_CONDITION;
            RoleImage.sprite = Resources.Load<Sprite>(RoleAndDescription.ICON_PATH_APOSTLE);
        }

        public void PriestRole() {
            RoleTitle.text = "- " + RoleAndDescription.PRIEST_NAME + " -";
            RoleDesciption.text = "Win Condition" + Environment.NewLine
                + RoleAndDescription.PRIEST_WIN_CONDITION;
            RoleImage.sprite = Resources.Load<Sprite>(RoleAndDescription.ICON_PATH_PRIEST);
        }

        public void AtheistRole() {
            RoleTitle.text = "- " + RoleAndDescription.ATHEIST_NAME + " -";
            RoleDesciption.text = "Win Condition" + Environment.NewLine
                + RoleAndDescription.ATHEIST_WIN_CONDITION;
            RoleImage.sprite = Resources.Load<Sprite>(RoleAndDescription.ICON_PATH_ATHEIST);
        }
        #endregion
    }
}
