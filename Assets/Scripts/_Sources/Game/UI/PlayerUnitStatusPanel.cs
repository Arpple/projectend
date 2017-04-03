using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using End.UI;
using UnityEngine.Assertions;

namespace End.Game.UI
{
	public class PlayerUnitStatusPanel : MonoBehaviour
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

		public GameEntity ShowingCharacter;

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

		public void SetCharacter(GameEntity characterEntity)
		{
			PlayerNameText.text = characterEntity.unit.OwnerEntity.player.PlayerObject.PlayerName;
			CharacterIcon.IconImage.sprite = characterEntity.unitIcon.IconSprite;

			UpdateUnitStatus(characterEntity.unitStatus);
			UpdateUnitHitpoint(characterEntity.hitpoint);

			ShowingCharacter = characterEntity;
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

		public void UpdateDeckCardCount(int count)
		{
			DeckCardCountText.text = count.ToString();
		}

		public void UpdateBoxCardCount(int count)
		{
			BoxCardCountText.text = count.ToString();
		}

		public void HideDisplay()
		{
			gameObject.SetActive(false);
			ShowingCharacter = null;
		}
	}
}
