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

			player.OnPlayerDisconnectCallback += () => {
				if (lobbyPlayer != null) Destroy(lobbyPlayer.gameObject);
			};
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
			player.OnMainMissionChangedCallback = MissionSelector.ShowMission;
			MissionSelector.ShowMission((MainMission)player.MainMissionId);
			player.OnReadyStateChangedCallback += UpdateMissionSelector;
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
			foreach(var mainMission in MissionSetting.MainMission.DataList)
			{
				MissionSelector.AddMission(mainMission);
			}
			MissionSelector.OnMissionSelected = SetMainMission;
			UpdateMissionSelector(false);
		}

		private void UpdateMissionSelector(bool isPlayerReady)
		{
			if(NetworkController.IsServer)
			{
				MissionSelector.SetConfigurable(!isPlayerReady);
			}
		}
	}
}
