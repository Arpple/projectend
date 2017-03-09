using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using End.Game.UI.CharactorSelection;
namespace End.UI.CharactorSelection {
    public class CharactorSelectionController : MonoBehaviour{
        public UnitStatus UnitStatus;
        public UnitSkill UnitSkill;
        //public List<>
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
            //TODO : Set Charactor Status
            //UnitStatus.setCharactorStatus();
            
            //TODO : Set Charactor Ability
            //UnitSkill.SetAbility();
        }
    }
}
