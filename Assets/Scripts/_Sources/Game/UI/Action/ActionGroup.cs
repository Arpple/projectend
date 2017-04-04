using UnityEngine;
using UnityEngine.Events;

namespace Game.UI
{
	public abstract class ActionGroup
	{
		protected abstract void Show();
		protected abstract void Hide();

		public event UnityAction OnCloseHandler;

		public ActionGroup ShowSubAction(ActionGroup action)
		{
			this.Hide();
			action.Show();
			action.OnCloseHandler += () => this.Show();

			return action;
		}

		public void CloseAction()
		{
			if (OnCloseHandler != null) OnCloseHandler();
			OnCloseHandler = null;
			Hide();
		}
	}

}
