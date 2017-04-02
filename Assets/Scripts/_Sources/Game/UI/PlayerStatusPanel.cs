using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using End.UI;
using UnityEngine.Assertions;

namespace End.Game.UI
{
	public class PlayerStatusPanel : MonoBehaviour
	{
		[Header("Player and Character")]
		public Text PlayerNameText;
		public Icon CharacterIcon;

		[Header("Character Status")]
		public Text DeckCardCountText;
		public Text BoxCardCountText;
		public Text AttackPowerText;
		public Text AttackRangeText;
		public Text MoveSpeedText;
		public Text VisionRangeText;
		public HpBar HpBar;

		private void Awake()
		{
			Assert.IsNotNull(PlayerNameText);
			Assert.IsNotNull(CharacterIcon);
			Assert.IsNotNull(DeckCardCountText);
			Assert.IsNotNull(BoxCardCountText);
			Assert.IsNotNull(AttackPowerText);
			Assert.IsNotNull(AttackRangeText);
			Assert.IsNotNull(MoveSpeedText);
			Assert.IsNotNull(VisionRangeText);
		}

		public void SetPlayer(GameEntity playerEntity)
		{
			PlayerNameText.text = playerEntity.player.PlayerObject.PlayerName;
		}

		public void SetCharacter(GameEntity characterEntity)
		{
			CharacterIcon.IconImage.sprite = characterEntity.unitIcon.IconSprite;
		}

		public void UpdateUnitStatus(UnitStatusComponent status)
		{
			AttackPowerText.text = status.AttackPower.ToString();
			AttackRangeText.text = status.AttackRange.ToString();
			MoveSpeedText.text = status.MoveSpeed.ToString();
			VisionRangeText.text = status.VisionRange.ToString();
			HpBar.SetMaxValue(status.HitPoint);
		}

		public void UpdateUnitHitpoint(HitpointComponent hp)
		{
			HpBar.UpdateHp(hp.Value);
		}
	}
}
