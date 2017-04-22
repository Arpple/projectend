using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lounge
{
	public class MissionBookDetailPage
	{
		private GameObject _pageDisplayPanel;
		private Text _missionNameText;
		private Text _missionTargetDescriptionText;
		private Text _missionDescriptionText;

		private List<MissionItem> _items;
		private MissionItem _currentItem;

		public MissionBookDetailPage(GameObject displayPanel, Text nameText, Text targetDescText, Text descText)
		{
			_pageDisplayPanel = displayPanel;
			_missionNameText = nameText;
			_missionTargetDescriptionText = targetDescText;
			_missionDescriptionText = descText;
			ClearText();
		}

		public void SetPageItems(List<MissionItem> items)
		{
			_items = items;
			foreach(var item in items)
			{
				item.SetOnSelectedAction(ShowItem);
			}
			
		}

		public void ShowPage()
		{
			_pageDisplayPanel.SetActive(true);
			foreach(var item in _items)
			{
				item.gameObject.SetActive(true);
			}
		}

		public void HidePage()
		{
			_pageDisplayPanel.SetActive(false);
			foreach (var item in _items)
			{
				item.gameObject.SetActive(false);
			}
			HideCurrentItem();
			ClearText();
			_currentItem = null;
		}

		public void ShowItem(MissionItem item)
		{
			HideCurrentItem();
			_currentItem = item;
			item.Focus();

			_missionNameText.text = item.GetMissionName();
			_missionTargetDescriptionText.text = item.GetMissionTarget();
			_missionDescriptionText.text = item.GetMissionDescription();
		}

		private void HideCurrentItem()
		{
			if (_currentItem != null)
			{
				_currentItem.UnFocus();
			}
		}

		private void ClearText()
		{
			_missionNameText.text = "-";
			_missionDescriptionText.text = "-";
			_missionTargetDescriptionText.text = "-";
		}
	}
}
