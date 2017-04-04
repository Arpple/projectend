using UnityEngine;

namespace Game.UI
{
	public class PlayerBox : CardContainer
	{
		public void AddCard(GameObject cardObject, int index)
		{
			base.AddCard(cardObject);
			cardObject.transform.SetSiblingIndex(index);
		}
	}

}
