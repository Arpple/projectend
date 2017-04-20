using System;
using UnityEngine;

[CreateAssetMenu(menuName = "End/Card/Resource", fileName = "new_card.asset")]
public class ResourceCardData : CardData, IIndexData<Resource>
{
	[Header("ResourceCard")]
	public Resource Type;

	public Resource GetIndex()
	{
		return Type;
	}

	public bool IsIndexEquals(Resource index)
	{
		return Type == index;
	}
}