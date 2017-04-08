using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Game.UI
{
	public abstract class ActionGroup
	{
		public abstract Button[] Buttons { get; }

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
		
		protected virtual void Show()
		{
			foreach (var btn in Buttons)
			{
				btn.gameObject.SetActive(true);
			}
		}

		protected virtual void Hide()
		{
			foreach (var btn in Buttons)
			{
				btn.onClick.RemoveAllListeners();
				btn.gameObject.SetActive(false);
			}
		}
	}
}
