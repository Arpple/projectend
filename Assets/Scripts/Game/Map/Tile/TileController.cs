using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End
{
	public class TileController : MonoBehaviour
	{
		public GameObject ViewContainer;

		private GameObject _tileView;

		public void RegistView(GameObject view)
		{
			view.transform.SetParent(ViewContainer.transform, false);
		}
			
		public delegate void TileClickAction();

		public TileClickAction ClickAction;

		void OnMouseDown()
		{
			if(ClickAction != null)
			{
				ClickAction();
			}
		}
	}
}

