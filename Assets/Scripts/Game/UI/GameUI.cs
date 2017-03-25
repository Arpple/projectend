using UnityEngine;

namespace End.Game.UI
{
	public class GameUI : MonoBehaviour
	{
		public static GameUI Instance;

		public ActionButtonController ActionButtonGroup;
		public InventoryGroup InventoryGroup;

		private void Awake()
		{
			Instance = this;

			ActionButtonGroup.Awake();
			InventoryGroup.Awake();
		}
	}
}

