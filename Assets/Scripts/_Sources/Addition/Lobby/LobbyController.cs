using System.Linq;
using Network;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Lobby
{
	public class LobbyController : MonoBehaviour
	{
		public static LobbyController Instance;

		public GameObject PlayerContainer;
		public Button BackButton;
		public Button ReadyButton;
		public Button WaitButton;
		public LobbyPlayer LobbyPlayerPrefabs;
		public MainMissionSelector MissionSelector;
		public MainMissionDisplay MissionDisplay;
		public RoundLimitSelector RoundSelector;
		public RoundLimitDisplay RoundDisplay;

		private Setting _setting;
		private LocalData _data;
		private Player _localPlayer;

		[Inject]
		public void Construct(Setting setting, LocalData data)
		{
			_setting = setting;
			_data = data;
		}

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(PlayerContainer);
			Assert.IsNotNull(BackButton);
			Assert.IsNotNull(ReadyButton);
			Assert.IsNotNull(WaitButton);
			Assert.IsNotNull(LobbyPlayerPrefabs);
			Assert.IsNotNull(MissionDisplay);
			Assert.IsNotNull(RoundSelector);
			Assert.IsNotNull(RoundDisplay);
		}

		private void Start()
		{
			BackButton.onClick.AddListener(Back);

			var netCon = NetworkController.Instance;
			netCon.OnAllPlayerReadyCallback = MoveToCharacterSelection;
			netCon.ClientPlayerStartCallback = AddPlayer;
			netCon.LocalPlayerStartCallback = SetLocalPlayer;
			RoundSelector.OnRoundLimitChanged = SetRound;
			CreateMissionSelection();
		}

		private void OnDestroy()
		{
			var netCon = NetworkController.Instance;
			netCon.ResetCallback();
		}

		public void AddPlayer(Player player)
		{
			var lobbyPlayer = Instantiate(LobbyPlayerPrefabs).GetComponent<LobbyPlayer>();
			lobbyPlayer.Init(this);
			lobbyPlayer.transform.SetParent(PlayerContainer.transform, false);
			lobbyPlayer.SetPlayer(player);
			lobbyPlayer.SetIcon(GetPlayerIcon((PlayerIcon)player.PlayerIconId));

			player.DisconnectCallback += () => {
				if (lobbyPlayer != null) Destroy(lobbyPlayer.gameObject);
			};

			if(NetworkController.IsServer)
			{
				if (_localPlayer != null)
				{
					player.MainMissionId = _localPlayer.MainMissionId;
					player.RoundLimit = _localPlayer.RoundLimit;
				}
			}
		}

		public void SetLocalPlayer(Player player)
		{
			_localPlayer = player;

			ReadyButton.onClick.AddListener(() =>
			{
				player.CmdSetReadyStatus(true);
				ReadyButton.gameObject.SetActive(false);
				WaitButton.gameObject.SetActive(true);
			});

			WaitButton.onClick.AddListener(() =>
			{
				player.CmdSetReadyStatus(false);
				ReadyButton.gameObject.SetActive(true);
				WaitButton.gameObject.SetActive(false);
			});

			player.CmdSetName(_data.PlayerName);
			player.CmdSetIcon((int)_data.PlayerIcon);
			
			player.ReadyStateUpdateAction += UpdateMissionSelector;
			player.MainMissionUpdateAction += UpdateMissionDisplay;

			player.ReadyStateUpdateAction += UpdateRoundSelector;
			player.RoundLimitUpdateAction += UpdateRoundDisplay;

			if (NetworkController.IsServer)
			{
				MissionSelector.SetMission((MainMission)player.MainMissionId);
				RoundSelector.SetRound(player.RoundLimit);
			}
		}

		public void Back()
		{
			NetworkController.Instance.Stop();
			SceneManager.LoadScene(GameScene.Title.ToString());
		}

		public void MoveToCharacterSelection()
		{
			var netCon = NetworkController.Instance;
			netCon.ServerResetPlayerReadyStatus();
			netCon.ServerChangeScene(GameScene.Lounge.ToString());
			netCon.StartGame();
		}

		public Sprite GetPlayerIcon(PlayerIcon icon)
		{
			return  _setting.PlayerIconSetting.GetData(icon).Icon;
		}

		#region Mission
		private void CreateMissionSelection()
		{
			foreach(var data in _setting.MissionSetting.MainMission.DataList.OrderBy(d => (int)d.Type))
			{
				MissionSelector.AddMission(data.Type);
			}
			MissionSelector.OnMissionChanged = ChangeMission;
		}

		private void ChangeMission(MainMission mission)
		{
			_localPlayer.CmdSetMainMission((int)mission);
		}

		private MainMissionData GetMissionData(MainMission mission)
		{
			return _setting.MissionSetting.MainMission.GetData(mission);
		}

		private MainMissionData GetMissionData(int mission)
		{
			return GetMissionData((MainMission)mission);
		}

		private void UpdateMissionSelector(bool isPlayerReady)
		{
			if (CanShowSelector(isPlayerReady))
			{
				MissionSelector.Show();
			}
			else
			{
				MissionSelector.Hide();
			}
		}

		private void UpdateMissionDisplay(MainMission mission)
		{
			MissionDisplay.ShowMission(GetMissionData(mission));
		}
		#endregion

		public void UpdateRoundSelector(bool isPlayerReady)
		{
			if (CanShowSelector(isPlayerReady))
			{
				RoundSelector.Show();
			}
			else
			{
				RoundSelector.Hide();
			}
		}

		public void UpdateRoundDisplay(int round)
		{
			RoundDisplay.ShowRoundLimit(round);
		}

		public void SetRound(int round)
		{
			_localPlayer.CmdSetRound(round);
		}

		protected virtual bool CanShowSelector(bool isPlayerReady)
		{
			return !isPlayerReady && NetworkController.IsServer;
		}
	}
}
