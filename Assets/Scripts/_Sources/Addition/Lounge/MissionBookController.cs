using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Lounge
{
	public class MissionBookController : MonoBehaviour
	{
		[Header("Controller")]
		public MissionItem MissionItemPrefabs;
		public Button MissionBookButton;
		public MissionBookMainPage MainPage;

		[Header("World Page")]
		public GameObject WorldMissionDetailPagePanel;
		public Transform WorldMissionObjectParent;
		public Text WorldMissionDetailPageNameText;
		public Text WorldMissionDetailPageDescText;
		public Text WorldMissionDetailPageTargetText;

		[Header("World Page")]
		public GameObject PlayerMissionDetailPagePanel;
		public Transform PlayerMissionObjectParent;
		public Text PlayerMissionDetailPageNameText;
		public Text PlayerMissionDetailPageDescText;
		public Text PlayerMissionDetailPageTargetText;


		private MissionBookDetailPage _worldMissionDetailPage;
		private MissionBookDetailPage _playerMissionDetailPage;

		private MissionSetting _setting;

		private void Awake()
		{
			_worldMissionDetailPage = new MissionBookDetailPage(WorldMissionDetailPagePanel, WorldMissionDetailPageNameText, WorldMissionDetailPageTargetText, WorldMissionDetailPageDescText);
			_playerMissionDetailPage = new MissionBookDetailPage(PlayerMissionDetailPagePanel, PlayerMissionDetailPageNameText, PlayerMissionDetailPageTargetText, PlayerMissionDetailPageDescText);
		}

		private void Start()
		{
			MissionBookButton.onClick.AddListener(ShowMainPage);
			MainPage.WorldPageButton.onClick.AddListener(ShowWorldMissionPage);
			MainPage.PlayerPageButton.onClick.AddListener(ShowPlayerMissionPage);
		}

		public void ShowMainPage()
		{
			_worldMissionDetailPage.HidePage();
			_playerMissionDetailPage.HidePage();

			MainPage.ShowPage();
		}

		public void ShowWorldMissionPage()
		{
			_playerMissionDetailPage.HidePage();
			MainPage.HidePage();

			_worldMissionDetailPage.ShowPage();
		}

		public void ShowPlayerMissionPage()
		{
			_worldMissionDetailPage.HidePage();
			MainPage.HidePage();

			_playerMissionDetailPage.ShowPage();
		}

		public void Close()
		{
			Debug.Log("Close");
			_playerMissionDetailPage.HidePage();
			_worldMissionDetailPage.HidePage();
			MainPage.HidePage();
		}

		public void LoadData(MissionSetting setting)
		{
			_setting = setting;
			CreatePlayerMissionItems(setting.PlayerMission.DataList);
			CreateMainMissionItems(setting.MainMission.DataList);
		}

		public void SetLocalMainMission(MainMission mission)
		{
			MainPage.SetWorldMission(_setting.MainMission.GetData(mission));
		}

		public void SetLocalPlayerMission(PlayerMission mission)
		{
			MainPage.SetPlayerMission(_setting.PlayerMission.GetData(mission));
		}

		public void SetLocalPlayerTarget(int targetId)
		{
			var target = Contexts.sharedInstance.game.GetEntities(GameMatcher.Player)
				.First(e => e.player.PlayerId == targetId);

			MainPage.SetPlayerMissionTarget(target);
		}

		private void CreatePlayerMissionItems(List<PlayerMissionData> datas)
		{
			List<MissionItem> items = new List<MissionItem>();
			foreach (var data in datas)
			{
				var item = CreateMissionItem(data);
				item.transform.SetParent(PlayerMissionObjectParent, false);
				items.Add(item);
			}
			_playerMissionDetailPage.SetPageItems(items);
		}

		private void CreateMainMissionItems(List<MainMissionData> datas)
		{
			List<MissionItem> items = new List<MissionItem>();
			foreach(var data in datas)
			{
				var item = CreateMissionItem(data);
				item.transform.SetParent(WorldMissionObjectParent, false);
				items.Add(item);
			}
			_worldMissionDetailPage.SetPageItems(items);
		}

		private MissionItem CreateMissionItem(MissionData data)
		{
			var item = Instantiate(MissionItemPrefabs);
			item.SetMissionData(data);
			return item;
		}
	}
}
