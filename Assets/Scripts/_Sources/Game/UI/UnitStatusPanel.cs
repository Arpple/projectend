using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using End.UI;
using UnityEngine.Assertions;

namespace End.Game.UI
{
	public class UnitStatusPanel : MonoBehaviour
	{
		[Header("Player and Character")]
		public Text PlayerNameText;
		public Text CharacterNameText;
		public Icon CharacterIcon;

		[Header("Character Status")]
		public Text DeckCardCountText;
		public Text BoxCardCountText;
		public Text AttackPowerText;
		public Text AttackRangeText;
		public Text MoveSpeedText;
		public Text VisionRangeText;

		private void Awake()
		{
			Assert.IsNotNull(PlayerNameText);
			Assert.IsNotNull(CharacterNameText);
			Assert.IsNotNull(CharacterIcon);
			Assert.IsNotNull(DeckCardCountText);
			Assert.IsNotNull(BoxCardCountText);
			Assert.IsNotNull(AttackPowerText);
			Assert.IsNotNull(AttackRangeText);
			Assert.IsNotNull(MoveSpeedText);
			Assert.IsNotNull(VisionRangeText);
		}

		public void UpdateUnitStatus(UnitStatusComponent status)
		{
			AttackPowerText.text = status.AttackPower.ToString();
			AttackRangeText.text = status.AttackRange.ToString();
			MoveSpeedText.text = status.MoveSpeed.ToString();
			VisionRangeText.text = status.VisionRange.ToString();
		}

	}
}
