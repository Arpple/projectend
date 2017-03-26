using System;

namespace End.Game.UI
{
	[Serializable]
	public class ActionButtonGroup
	{
		public ActionButton[] AllActions
		{
			get; protected set;
		}

		public void ToggleVisibility(bool isVisible)
		{
			foreach (var a in AllActions)
			{
				a.gameObject.SetActive(isVisible);
			}
		}
	}
}
