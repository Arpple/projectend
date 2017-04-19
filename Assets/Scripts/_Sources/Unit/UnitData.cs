using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "End/Unit/Unit", fileName = "new_unit.asset")]
public class UnitData : EntityData
{
	[Header("Sprite")]
	public Sprite BodySprite;
	public Sprite IconSprite;

	[Header("UnitDetail")]
	public string Name;
	[TextArea] public string Description;

	[Header("UnitStatus")]
	public int HitPoint;
	public int AttackPower;
	public int AttackRange;
	public int VisionRange;
	public int MoveSpeed;
}
