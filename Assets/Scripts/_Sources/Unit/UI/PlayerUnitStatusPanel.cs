using UI;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PlayerUnitStatusPanel : MonoBehaviour
{
	[Header("Player and Character")]
	public Text PlayerNameText;
	public Icon CharacterIcon;

    [Header("Turn")]
    public Image CrownImage;

	[Header("Character Status")]
	public Text DeckCardCountText;
	public Text BoxCardCountText;
	public Text AttackPowerText;
	public Text AttackRangeText;
	public Text MoveSpeedText;
	public Text VisionRangeText;
	public HpBar HpBar;

	[Header("Role")]
	public Text RoleText;
	public Icon RoleImage;

    [Header("Animation")]
    public Animator AnimeCon;

	public UnitEntity ShowingCharacter;

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

		//Role
		Assert.IsNotNull(RoleText);
		Assert.IsNotNull(RoleImage);

        Assert.IsNotNull(AnimeCon);
	}

	public void SetCharacter(UnitEntity entity)
	{
        AnimeCon.Play("ShowDisplayStatus");
		UpdatePlayerName(entity);
		CharacterIcon.IconImage.sprite = entity.unitIcon.IconSprite;
		UpdateUnitStatus(entity.unitStatus);
		UpdateUnitHitpoint(entity.hitpoint);

		ShowingCharacter = entity;

        //Show Crown when current Turn.
        CrownImage.gameObject.SetActive(entity.owner.Entity.isPlaying);
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
        AnimeCon.Play("HideDisplayStatus");
		gameObject.SetActive(false);
		ShowingCharacter = null;
	}

	private void UpdatePlayerName(UnitEntity entity)
	{
		PlayerNameText.text = entity.owner.Entity.player.PlayerObject.GetName();
	}
}
