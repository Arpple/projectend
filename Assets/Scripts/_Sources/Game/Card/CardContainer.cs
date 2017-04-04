using UnityEngine;
using System.Collections;

namespace Game.UI
{
	public class CardContainer : MonoBehaviour
	{
		public GameObject ObjectContainer;

		public void Init()
		{
			ObjectContainer = ObjectContainer ?? gameObject;
		}

		public void AddCard(GameObject cardObject)
		{
			cardObject.transform.SetParent(ObjectContainer.transform, false);
		}
	}
}
