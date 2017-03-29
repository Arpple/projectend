using UnityEngine;

namespace End.Game.UI
{
	public class PlayerBox : MonoBehaviour
	{
		public GameObject Content;

		public void Init()
		{
			Content = Content ?? gameObject;
		}

		public void AddCard(GameObject cardObject)
		{
			cardObject.transform.SetParent(Content.transform, false);
		}
	}

}
