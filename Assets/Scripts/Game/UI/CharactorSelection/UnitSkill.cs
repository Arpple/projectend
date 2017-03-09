using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace End.Game.UI.CharactorSelection {
    public class UnitSkill : MonoBehaviour{
        public Icon[] AbilityIcon;
        public Text TextAbilityName,TextDescription;
        private List<object> _charactorAbilityList;

        public void SetAbility(List<object> ability) {
            this._charactorAbilityList = ability;
            renderAbility();
        }

        private void renderAbility() {
            int len = AbilityIcon.Length;
            for(int i=0;i<len;i++) {
                if(i<_charactorAbilityList.Count) {
                    AbilityIcon[i].gameObject.SetActive(true);
                    //TODO : Set Ability Icon
                    
                }else {
                    //TODO : No Skill disable icon view
                    AbilityIcon[i].gameObject.SetActive(false);
                }

            }
        }
    }
}
