using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game.UI
{
	public class PlayerDeck : MonoBehaviour
	{
		public GameObject Content;

		public void Init()
		{
			Content = Content ?? Instantiate(new GameObject("Content"), transform, false) as GameObject;
		}

		public void AddCard(GameObject cardObject)
		{
			cardObject.transform.SetParent(Content.transform, false);
		}
	}

}
