using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Lounge
{
	public class UnitSkillObject : MonoBehaviour
	{
		public Icon SkillIcon;
		public Button Button;

		private SkillCardData _data;

		public void SetSkillData(SkillCardData skillData)
		{
			_data = skillData;
			SkillIcon.SetImage(skillData.MainSprite);
		}

		public string GetSkillDescription()
		{
			//TODO: passive
			return _data.ActiveDesc;
		}

		public string GetSkillName()
		{
			return _data.Name;
		}
	}
}
