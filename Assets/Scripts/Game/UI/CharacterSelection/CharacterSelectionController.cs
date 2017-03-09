using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using End.Game.UI.CharacterSelection;
namespace End.UI.CharacterSelection {
    public class CharacterSelectionController : MonoBehaviour{
        public UnitStatus UnitStatus;
        public UnitSkill UnitSkill;
        //public Text
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
            //TODO : Set Character Status
            //UnitStatus.setCharacterStatus();
            
            //TODO : Set Character Ability
            //UnitSkill.SetAbility();
        }
    }
}
