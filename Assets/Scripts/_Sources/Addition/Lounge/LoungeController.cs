using System.Collections.Generic;
using System.Linq;
using Entitas.Unity;
using Network;
using UI;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Lounge
{
	public class LoungeController : MonoBehaviour{

		public static LoungeController Instance;	

		public UnitStatusPanel UnitStatus;
		public UnitSkillPanel UnitSkill;

		public GameObject RoleContent,CharacterContent,PlayerListContent;
		public SlideMenu CharacterSelectSlideMenu;
		public Button LockButton;
		public LoungePlayer CharacterSelectPlayerPrefabs;

		public Setting Setting;

		private Character _focusingCharacter;
		private Player _localPlayer;

        [Header("MissionBook")]
        public MissionBookController MissionBook;

		[Header("Test")]
		public bool IsOffline;
		public Transform PlayerParent;

		private NetworkController _networkController
		{
			get { return NetworkController.Instance; }
		}

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(UnitStatus);
			Assert.IsNotNull(UnitSkill);
			Assert.IsNotNull(RoleContent);
			Assert.IsNotNull(CharacterContent);
			Assert.IsNotNull(CharacterSelectSlideMenu);
			Assert.IsNotNull(LockButton);
			Assert.IsNotNull(CharacterSelectPlayerPrefabs);
			Assert.IsNotNull(Setting);
		}

		void Start()
		{
			MissionBook.LoadData(Setting.MissionSetting);
			UnitSkill.Initialize(Setting.CardSetting.SkillCardSetting);

			foreach (var player in GetAllPlayers())
			{
				AddPlayer(player);
			}

			SetLocalPlayer(GetLocalPLayer());

			CharacterSelectSlideMenu.OnFocusItemChangedCallback += FocusCharacterIcon;

			if(!IsOffline)
			{
				_networkController.ServerSceneChangedCallback = _networkController.LocalPlayer.RpcResetReadyStatus;
				_networkController.OnAllPlayerReadyCallback += LoadGameScene;
			}
		}

		private void FocusCharacterIcon(SlideItem characterIcon)
		{
			var entity = (UnitEntity)characterIcon.gameObject.GetEntityLink().entity;
			_focusingCharacter = entity.character.Type;

			ShowUnitInformationUnit(entity);
		}

		private void OnDestroy()
		{
			if(!IsOffline)
			{
				var netCon = NetworkController.Instance;

				netCon.ServerSceneChangedCallback = null;
				netCon.OnAllPlayerReadyCallback -= LoadGameScene;
			}
		}

		/// <summary>
		/// Lock character selection
		/// </summary>
		public void Lock()
		{
			_localPlayer.CmdSetCharacterId((int)_focusingCharacter);
		}

		/// <summary>
		/// Show Unit Info 
		/// </summary>
		public void ShowUnitInformationUnit(UnitEntity unit) {
			UnitStatus.SetUnit(unit);
			UnitSkill.SetUnit(unit);
		}

		
		private void AddPlayer(Player player)
		{
			LoungePlayer charPlayer = Instantiate(CharacterSelectPlayerPrefabs,PlayerListContent.transform,false);
			charPlayer.SetPlayer(player);

			player.OnSelectedCharacterChangedCallback += DisableCharacterIcon;
			player.OnPlayerMissionChangedCallback = MissionBook.SetLocalPlayerMission;
			player.OnPlayerMissionTargetIdChangedCallback = MissionBook.SetLocalPlayerTarget;
		}

		public void SetLocalPlayer(Player player)
		{
			_localPlayer = player;
			_localPlayer.OnSelectedCharacterChangedCallback += OnLocalPlayerCharacterSelected;

			MissionBook.SetLocalMainMission((MainMission)player.MainMissionId);
			if(IsOffline)
			{
				MissionBook.SetLocalPlayerMission((PlayerMission)player.PlayerMissionId);
				MissionBook.SetLocalPlayerTarget(player.PlayerMissionTarget);
			}
		}

		/// <summary>
		/// Called when player is assigned character
		/// </summary>
		/// <param name="characterId">The character identifier.</param>
		public void OnLocalPlayerCharacterSelected(int characterId)
		{
			StartCoroutine(Ready());
			LockButton.interactable = false;
		}

		System.Collections.IEnumerator Ready()
		{
			yield return new WaitForEndOfFrame();
			_localPlayer.CmdSetReadyStatus(true);
		}

		/// <summary>
		/// Disables the character selection icon.
		/// </summary>
		/// <param name="charId">The character identifier.</param>
		public void DisableCharacterIcon(int charId)
		{
			var character = (Character)charId;
			Assert.AreNotEqual(Character.None, character);

			var item = CharacterSelectSlideMenu.SlideItems.First(i =>
			{
				var entity = (UnitEntity)i.gameObject.GetEntityLink().entity;
				return entity.character.Type == character;
			});

			//TODO: disable 'item'
			Debug.Log("disable " + item);
		}

		/// <summary>
		/// Moves to game. (Server)
		/// </summary>
		public void LoadGameScene()
		{
			var netCon = NetworkController.Instance;
			netCon.ServerChangeScene(Scene.Game.ToString());
		}

		public List<Player> GetAllPlayers()
		{
			return IsOffline
				? PlayerParent.GetComponentsInChildren<Player>(true).ToList()
				: _networkController.AllPlayers;
		}

		public Player GetLocalPLayer()
		{
			return IsOffline
				? PlayerParent.GetChild(0).GetComponent<Player>()
				: _networkController.LocalPlayer;
		}
	}
}
