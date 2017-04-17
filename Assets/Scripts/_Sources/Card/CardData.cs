using UnityEngine;

public abstract class CardData : EntityData
{
	[Header("Card")]
	public Sprite MainSprite;

	public string Name;
	[TextArea] public string ActiveDesc;
	[TextArea] public string PassiveDesc;
}