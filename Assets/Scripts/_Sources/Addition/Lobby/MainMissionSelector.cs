using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Lobby
{
	public class MainMissionSelector : MonoBehaviour
	{
		public MainMissionSelectorObject MissionObjectPrefabs;
		public Transform MissionObjectParent;
		public Button LeftArrow;
		public Button RightArrow;

		public UnityAction<MainMission> OnMissionSelected;

		private Dictionary<MainMission, MainMissionSelectorObject> _missionObjects;
		private int _missionCount;
		private int _selectedIndex;

		private void Awake()
		{
			_missionObjects = new Dictionary<MainMission, MainMissionSelectorObject>();
			_missionCount = Enum.GetNames(typeof(MainMission)).Length;
			Assert.IsTrue(_missionCount > 0);
			_selectedIndex = 0;

			SetConfigurable(false);
		}

		private void Start()
		{
			LeftArrow.onClick.AddListener(MoveLeft);
			RightArrow.onClick.AddListener(MoveRight);
		}

		public void LoadDatas(List<MainMissionData> datas)
		{
			foreach (var mainMission in datas)
			{
				AddMission(mainMission);
			}
		}

		public void SetConfigurable(bool isEnable)
		{
			LeftArrow.gameObject.SetActive(isEnable);
			RightArrow.gameObject.SetActive(isEnable);
		}

		public void AddMission(MainMissionData data)
		{
			var missionObj = Instantiate(MissionObjectPrefabs, MissionObjectParent, false);
			missionObj.SetMissionData(data);
			missionObj.gameObject.SetActive(false);
			_missionObjects.Add(data.Type, missionObj);

			UpdateSelection();
		}

		public void ShowMission(MainMission mission)
		{
			MainMissionSelectorObject missionObject;
			if (_missionObjects.TryGetValue(mission, out missionObject))
			{
				ChangeSelectedMission((int)mission);
				UpdateSelection();
			}
		}

		private void MoveLeft()
		{
			if (!CanMoveLeft()) return;
			SelectMission(GetSelectedMission() - 1);
		}

		private void MoveRight()
		{
			if (!CanMoveRight()) return;
			SelectMission(GetSelectedMission() + 1);
		}

		private void ChangeSelectedMission(int newIndex)
		{
			HideSelectedMission();
			_selectedIndex = newIndex;
			ShowSelectedMission();
		}

		private void UpdateSelection()
		{
			LeftArrow.interactable = CanMoveLeft();
			RightArrow.interactable = CanMoveRight();
		}

		private bool CanMoveLeft()
		{
			return _selectedIndex > 0;
		}

		private bool CanMoveRight()
		{
			return _selectedIndex < _missionCount - 1;
		}

		private void HideSelectedMission()
		{
			_missionObjects[GetSelectedMission()].gameObject.SetActive(false);
		}

		private MainMission GetSelectedMission()
		{
			return (MainMission)_selectedIndex;
		}

		private void ShowSelectedMission()
		{
			_missionObjects[GetSelectedMission()].gameObject.SetActive(true);
		}

		private void SelectMission(MainMission mission)
		{
			if (OnMissionSelected != null)
			{
				OnMissionSelected(mission);
			}
		}
	}
}
