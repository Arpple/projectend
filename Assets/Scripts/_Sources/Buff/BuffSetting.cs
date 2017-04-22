using System;
using UnityEngine;

[Serializable]
public class BuffSetting : IndexDataList<Buff, BuffData>
{
	[Header("Exhaust")]
	public int ExhaustDamageReduceAmount;
}