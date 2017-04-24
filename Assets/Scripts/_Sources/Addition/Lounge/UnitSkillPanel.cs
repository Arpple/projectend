using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lounge
{
	public class UnitSkillPanel : MonoBehaviour{

		public UnitSkillObject SkillObjectPrefabs;
		public Transform SkillObjectParent;

		public Text SkillNameText;
		public Text SkillDescriptionText;

		private List<UnitSkillObject> _skills;
		private SkillCardSetting _setting;

		private void Awake()
		{
			_skills = new List<UnitSkillObject>();
		}

		public void LoadData(SkillCardSetting setting)
		{
			_setting = setting;
		}

		public void SetUnit(UnitEntity unit)
		{
			ClearOldUnitSkill();
			LoadUnitSkills(unit);
		}

		private void ClearOldUnitSkill()
		{
			foreach(var s in _skills)
			{
				Destroy(s.gameObject);
			}
			_skills.Clear();
		}

		private void LoadUnitSkills(UnitEntity unit)
		{
			if (!unit.hasCharacterSkillsResource) return;
			foreach (var skill in unit.characterSkillsResource.Skills)
			{
				CreateSkillObject(skill);
			}
		}

		private void CreateSkillObject(SkillCard skill)
		{
			var obj = Instantiate(SkillObjectPrefabs, SkillObjectParent, false);
			obj.SetSkillData(_setting.GetData(skill));
			_skills.Add(obj);

			obj.Button.onClick.AddListener(() => ShowSkillDetail(obj));
		}

		private void ShowSkillDetail(UnitSkillObject obj)
		{
			SkillNameText.text = obj.GetSkillName();
			SkillDescriptionText.text = obj.GetSkillDescription();
		}

        //public void SetAbility(List<object> ability) {
        //    this._characterAbilityList = ability;
        //    renderAbility();
        //}

        //private void renderAbility() {
        //    int len = AbilityIcon.Length;
        //    for(int i=0;i<len;i++) {
        //        if(i<_characterAbilityList.Count) {
        //            AbilityIcon[i].gameObject.SetActive(true);
        //            //TODO : Set Ability Icon
                    
        //        }else {
        //            //TODO : No Skill disable icon view
        //            AbilityIcon[i].gameObject.SetActive(false);
        //        }

        //    }
        //}
    }
}
