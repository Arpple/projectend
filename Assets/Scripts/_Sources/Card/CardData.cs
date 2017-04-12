using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "End/Card", fileName = "new_card.asset")]
public class CardData : EntityData
{
	public Card Type;

	[Header("Sprite")]
	public Sprite MainSprite;

	[Header("Ability")]
	public string AbilityClassFullName;
}