using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Game.UI
{
	public class ActionButton : MonoBehaviour
	{
		public delegate void ClickCallback();
		public event ClickCallback OnClickCallback;

		public Button Button;

		private void Awake()
		{
			Assert.IsNotNull(Button);
		}

		public void Click()
		{
			ClickAction();
			if(OnClickCallback != null)OnClickCallback();
		}

		protected virtual void ClickAction()
		{ }
	}
}

