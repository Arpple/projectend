using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;

namespace CharacterSelect {
    public class UnitSkill : MonoBehaviour{
        public Icon[] AbilityIcon;
        public Text TextAbilityName,TextDescription;
        private List<object> _characterAbilityList;

        public void SetAbility(List<object> ability) {
            this._characterAbilityList = ability;
            renderAbility();
        }

        private void renderAbility() {
            int len = AbilityIcon.Length;
            for(int i=0;i<len;i++) {
                if(i<_characterAbilityList.Count) {
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
