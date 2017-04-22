using UnityEngine;

[CreateAssetMenu(menuName = "End/Buff", fileName = "buff.asset")]
public class BuffData : EntityData, IIndexData<Buff>
{
	public Buff Type;
	public string Name;
	public Sprite Icon;
	public int Duration;

	public Buff GetIndex()
	{
		return Type;
	}

	public bool IsIndexEquals(Buff index)
	{
		return Type == index;
	}
}