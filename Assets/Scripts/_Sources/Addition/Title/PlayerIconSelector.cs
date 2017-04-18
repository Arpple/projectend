using UI;
using UnityEngine;
using Network;

namespace Title
{
	public class PlayerIconSelector : MonoBehaviour
	{
		public Icon PlayerIcon;
		public Transform IconParentObject;

		public PlayerIconSelectorObject IconPrefabs;

		private PlayerIconSelectorObject _selectedObject;

		public void AddIcon(PlayerIconData data)
		{
			var icon = Instantiate(IconPrefabs, IconParentObject, false);
			icon.SetIcon(data);
			icon.OnIconSelected = SetPlayerIcon;
		}

		private void SetPlayerIcon(PlayerIconSelectorObject playerIcon)
		{
			if (_selectedObject == playerIcon) return;

			UnselectedPreviousIcon();
			PlayerIcon.SetImage(playerIcon.GetIcon());
			NetworkController.Instance.LocalPlayerIconType = playerIcon.GetIconType();
			_selectedObject = playerIcon;
		}

		private void UnselectedPreviousIcon()
		{
			if (_selectedObject != null)
			{
				_selectedObject.UnSelected();
			}
		}
	}
}
