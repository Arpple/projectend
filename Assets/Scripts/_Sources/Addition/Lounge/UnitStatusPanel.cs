using UnityEngine;
using UnityEngine.UI;

namespace Lounge
{
	public class UnitStatusPanel : MonoBehaviour{

		public Image UnitImage;

		[Header("Status")]
		public Text HitPoint;
		public Text AttackPower;
		public Text AttackRange;
		public Text VisionRange;
		public Text MoveSpeed;
		public Text UnitName;

		[Header("Skill")]
		UnitSkillPanel SkillPanel;
		

		public void SetUnit(UnitEntity unit)
		{
			SetUnitDetail(unit.unitDetail);
			SetUnitStatus(unit.unitStatus);
			SetUnitSprite(unit.sprite.Sprite);
		}

		private void SetUnitDetail(UnitDetailComponent detail)
		{
			UnitName.text = detail.Name;
		}

		private void SetUnitStatus(UnitStatusComponent status)
		{
			HitPoint.text = status.HitPoint.ToString();
			AttackPower.text = status.AttackPower.ToString();
			AttackRange.text = status.AttackRange.ToString();
			VisionRange.text = status.VisionRange.ToString();
			MoveSpeed.text = status.MoveSpeed.ToString();
		}

		private void SetUnitSprite(Sprite sprite)
		{
			UnitImage.sprite = sprite;
		}
	}
}
