using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Network;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Lobby
{
	public class MainMissionSelector : MonoBehaviour
	{
		public Button LeftButton;
		public Button RightButton;
		public UnityAction<MainMission> OnMissionChanged;

		private TwoWayObjectSelector<MainMission> _missions;

		private void Awake()
		{
			_missions = new TwoWayObjectSelector<MainMission>();
		}

		private void Start()
		{
			if(!NetworkController.IsServer)
			{
				Hide();
			}
			LeftButton.onClick.AddListener(ChangeToLeftMission);
			RightButton.onClick.AddListener(ChangeToRigthMission);
		}

		public void AddMission(MainMission mission)
		{
			_missions.AddItem(mission);
		}

		public void UpdateButtonInteractable()
		{
			LeftButton.interactable = _missions.CanMoveDown();
			RightButton.interactable = _missions.CanMoveUp();
		}

		public void SetMission(MainMission mission)
		{
			_missions.SetSelectedItem(mission);
			UpdateMission();
		}

		public void ChangeToLeftMission()
		{
			_missions.MoveIndexDown();
			UpdateMission();
		}

		public void ChangeToRigthMission()
		{
			_missions.MoveIndexUp();
			UpdateMission();
		}

		public void Hide()
		{
			LeftButton.gameObject.SetActive(false);
			RightButton.gameObject.SetActive(false);
		}

		public void Show()
		{
			LeftButton.gameObject.SetActive(true);
			LeftButton.gameObject.SetActive(true);
		}

		private void UpdateMission()
		{
			UpdateButtonInteractable();
			if (OnMissionChanged != null)
			{
				OnMissionChanged(_missions.GetCurrentITem());
			}
		}
	}
}
