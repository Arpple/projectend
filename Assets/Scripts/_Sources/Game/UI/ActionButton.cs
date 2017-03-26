using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace End.Game.UI
{
	public class ActionButton : MonoBehaviour
	{
		public delegate void ClickCallback(ActionButton btn);
		public event ClickCallback OnClickCallback;

		public Button Button;

		private void Awake()
		{
			Assert.IsNotNull(Button);
		}

		public void Click()
		{
			ClickAction();
			if(OnClickCallback != null)OnClickCallback(this);
		}

		protected virtual void ClickAction()
		{ }
	}
}

