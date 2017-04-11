using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UI
{
	public abstract class ActionGroup
	{
		public ActionGroup PreviousGroup;

		public abstract Button[] Buttons { get; }

		public ActionGroup ShowSubAction(ActionGroup action)
		{
			Hide();
			action.Show();
			action.PreviousGroup = this;
			return action;
		}

		public void CloseAction()
		{
			Hide();
			PreviousGroup.Show();
		}
		
		protected virtual void Show()
		{
			GameUI.Instance.SetCurrentGroup(this);
			foreach (var btn in Buttons)
			{
				btn.gameObject.SetActive(true);
			}
		}

		protected virtual void Hide()
		{
			foreach (var btn in Buttons)
			{
				btn.gameObject.SetActive(false);
			}
		}
	}
}
