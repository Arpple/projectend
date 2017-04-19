using UI;
using UnityEngine;

namespace Lounge
{
	public class UnitSkillObject : MonoBehaviour
	{
		public Icon SkillIcon;

		public void SetSkill(SkillCardData skillData)
		{
			SkillIcon.SetImage(skillData.MainSprite);
		}
	}
}
