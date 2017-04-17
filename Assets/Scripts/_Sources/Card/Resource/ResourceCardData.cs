using UnityEngine;

[CreateAssetMenu(menuName = "End/Card - Resource", fileName = "new_card.asset")]
public class ResourceCardData : CardData
{
	[Header("ResourceCard")]
	public Resource Type;
}