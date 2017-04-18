using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Title
{
	public class PlayerIconSelectorObject : MonoBehaviour
	{
		public Icon Icon;
		public UnityAction<PlayerIconSelectorObject> OnIconSelected;
		public Color SelectedBorderColor;
		public Color UnSelectedBorderColor;

		private PlayerIcon _iconType;

		public void SetIcon(PlayerIconData data)
		{
			_iconType = data.Type;
			Icon.SetImage(data.Icon);
		}

		public Sprite GetIcon()
		{
			return Icon.IconImage.sprite;
		}

		public void OnClick()
		{
			Icon.SetBorderColor(SelectedBorderColor);
			if(OnIconSelected != null)
			{
				OnIconSelected(this);
			}
		}

		public void UnSelected()
		{
			Icon.SetBorderColor(UnSelectedBorderColor);
		}

		public PlayerIcon GetIconType()
		{
			return _iconType;
		}
	}
}
