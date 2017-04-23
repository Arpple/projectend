using Network;
using UI;
using UnityEngine;
using Zenject;

namespace Title
{
	public class PlayerIconSelector : MonoBehaviour
	{
		public Icon PlayerIcon;
		public Transform IconParentObject;

		public PlayerIconSelectorObject IconPrefabs;

		private PlayerIconSelectorObject _selectedObject;
		private LocalData _data;

		[Inject]
		public void Construct(LocalData data)
		{
			_data = data;
		}

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
			_data.PlayerIcon = playerIcon.GetIconType();
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
