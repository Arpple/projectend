using System.Linq;
using Network;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

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

		[Header("Setting")]
		public Title.TitleSetting TitleSetting;
		public MissionSetting MissionSetting;

		private Player _localPlayer;

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(PlayerContainer);
			Assert.IsNotNull(BackButton);
			Assert.IsNotNull(ReadyButton);
			Assert.IsNotNull(WaitButton);
			Assert.IsNotNull(LobbyPlayerPrefabs);
			Assert.IsNotNull(TitleSetting);
			Assert.IsNotNull(MissionSetting);
			Assert.IsNotNull(MissionDisplay);
		}

		private void Start()
		{
			ReadyButton.onClick.RemoveAllListeners();
			WaitButton.onClick.RemoveAllListeners();
			BackButton.onClick.RemoveAllListeners();

			BackButton.onClick.AddListener(Back);

			var netCon = NetworkController.Instance;
			netCon.OnAllPlayerReadyCallback += MoveToCharacterSelection;
			netCon.OnClientPlayerStartCallback += AddPlayer;
			netCon.OnLocalPlayerStartCallback += SetLocalPlayer;

			CreateMissionSelection();
		}

		private void OnDestroy()
		{
			var netCon = NetworkController.Instance;
			netCon.OnAllPlayerReadyCallback -= MoveToCharacterSelection;
			netCon.OnClientPlayerStartCallback -= AddPlayer;
			netCon.OnLocalPlayerStartCallback -= SetLocalPlayer;

			_localPlayer.OnReadyStateChangedCallback -= UpdateMissionSelector;
			_localPlayer.OnMainMissionChangedCallback = null;
		}

		public void AddPlayer(Player player)
		{
			var lobbyPlayer = Instantiate(LobbyPlayerPrefabs).GetComponent<LobbyPlayer>();
			lobbyPlayer.Init(this);
			lobbyPlayer.transform.SetParent(PlayerContainer.transform, false);
			lobbyPlayer.SetPlayer(player);
			lobbyPlayer.SetIcon(GetPlayerIcon((Title.PlayerIcon)player.PlayerIconId));

			player.OnPlayerDisconnectCallback += () => {
				if (lobbyPlayer != null) Destroy(lobbyPlayer.gameObject);
			};

			if(NetworkController.IsServer)
			{
				if(_localPlayer != null)
					player.MainMissionId = _localPlayer.MainMissionId;
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

			player.CmdSetName(NetworkController.Instance.LocalPlayerName);
			player.CmdSetIcon((int)NetworkController.Instance.LocalPlayerIconType);
			
			player.OnReadyStateChangedCallback += UpdateMissionSelector;
			player.OnMainMissionChangedCallback = UpdateMissionDisplay;

			if (NetworkController.IsServer)
			{
				MissionSelector.SetMission((MainMission)player.MainMissionId);
			}
		}

		public void Back()
		{
			NetworkController.Instance.Stop();
			UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.Title.ToString());
		}

		public void MoveToCharacterSelection()
		{
			var netCon = NetworkController.Instance;
			netCon.ServerChangeScene(Scene.Lounge.ToString());
			netCon.StartGame();
		}

		public void SetMainMission(MainMission mission)
		{
			_localPlayer.CmdSetMainMission((int)mission);
		}

		public Sprite GetPlayerIcon(Title.PlayerIcon icon)
		{
			return TitleSetting.PlayerIconList.GetData(icon).Icon;
		}

		private void CreateMissionSelection()
		{
			foreach(var data in MissionSetting.MainMission.DataList.OrderBy(d => (int)d.Type))
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
			return MissionSetting.MainMission.GetData(mission);
		}

		private MainMissionData GetMissionData(int mission)
		{
			return GetMissionData((MainMission)mission);
		}

		private void UpdateMissionSelector(bool isPlayerReady)
		{
			if(isPlayerReady)
			{
				MissionSelector.Hide();
			}
			else
			{
				MissionSelector.Show();
			}
		}

		private void UpdateMissionDisplay(MainMission mission)
		{
			MissionDisplay.ShowMission(GetMissionData(mission));
		}
	}
}
