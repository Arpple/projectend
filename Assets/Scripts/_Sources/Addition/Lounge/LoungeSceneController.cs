using System.Collections;
using System.Linq;
using Entitas;
using Entitas.Unity;
using Network;
using UI;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Zenject;

namespace Lounge
{
	[RequireComponent(typeof(SceneLoader), typeof(IPlayerLoader))]
	public abstract class LoungeSceneController : MonoBehaviour
	{
		public UnitStatusPanel UnitStatus;
		public UnitSkillPanel UnitSkill;

		public GameObject CharacterContent, PlayerListContent;
		public SlideMenu CharacterSelectSlideMenu;
		public Button LockButton;
		public LoungePlayer CharacterSelectPlayerPrefabs;

		[Header("MissionBook")]
		public MissionBookController MissionBook;

		protected Setting _setting;
		protected Character _focusingCharacter;
		protected Player _localPlayer;
		protected SceneLoader _sceneLoader;

		private IPlayerLoader _playerLoader;
		private Systems _systems;
		private Contexts _contexts;
		private bool _isInit;

		[Inject]
		public void Construct(Setting setting)
		{
			_setting = setting;
		}

		private void Awake()
		{
			_playerLoader = GetComponent<IPlayerLoader>();
			_sceneLoader = GetComponent<SceneLoader>();

			
		}

		protected virtual void Start()
		{
			_localPlayer = _playerLoader.GetLocalPlayer();
			MissionBook.LoadData(_setting.MissionSetting);
			UnitSkill.Initialize(_setting.CardSetting.SkillCardSetting);
			LockButton.onClick.AddListener(LockFocusingCharacter);
			CharacterSelectSlideMenu.OnFocusItemChangedCallback += FocusCharacterIcon;

			SetupSystems();

			foreach (var p in _playerLoader.GetAllPlayer())
			{
				SetupPlayer(p);
			}
			
			SetupLocalPlayer(_localPlayer);
		}

		private void Update()
		{
			if (!_isInit) return;
			if (!_sceneLoader.IsReady()) return;

			_systems.Execute();
			_systems.Cleanup();
		}

		private void OnDestroy()
		{
			_systems.ClearReactiveSystems();
			_systems.TearDown();
		}

		protected abstract void LockFocusingCharacter();

		private void FocusCharacterIcon(SlideItem characterIcon)
		{
			var entity = (UnitEntity)characterIcon.gameObject.GetEntityLink().entity;
			_focusingCharacter = entity.character.Type;

			ShowUnitInformationUnit(entity);
		}

		private void ShowUnitInformationUnit(UnitEntity unit)
		{
			UnitStatus.SetUnit(unit);
			UnitSkill.SetUnit(unit);
		}

		private void SetupPlayer(Player player)
		{
			LoungePlayer charPlayer = Instantiate(CharacterSelectPlayerPrefabs, PlayerListContent.transform, false);
			charPlayer.SetPlayer(player);

			player.OnSelectedCharacterChangedCallback += DisableCharacterIcon;
			player.OnPlayerMissionChangedCallback = MissionBook.SetLocalPlayerMission;
			player.OnPlayerMissionTargetIdChangedCallback = MissionBook.SetLocalPlayerTarget;
		}

		private void DisableCharacterIcon(int charId)
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

		protected virtual void SetupLocalPlayer(Player player)
		{
			player.OnSelectedCharacterChangedCallback += OnLocalPlayerCharacterSelected;
			MissionBook.SetLocalMainMission((MainMission)player.MainMissionId);
		}

		private  void OnLocalPlayerCharacterSelected(int characterId)
		{
			StartCoroutine(Ready());
			LockButton.interactable = false;
		}

		IEnumerator Ready()
		{
			yield return new WaitForEndOfFrame();
			_localPlayer.CmdSetReadyStatus(true);
		}

		private void SetupSystems()
		{
			_contexts = Contexts.sharedInstance;
			_systems = CreateSystems(_contexts);

			_systems.Initialize();
			_isInit = true;
		}

		Systems CreateSystems(Contexts contexts)
		{
			var players = _playerLoader.GetAllPlayer();

			var systems = new Feature("Systems")
				.Add(new PlayerCreatingSystem(contexts, players))
				.Add(new LocalPlayerSetupSystem(contexts, _localPlayer))
				.Add(new CharacterLoadingSystems(contexts))
				.Add(new CharacterDataLoadingSystem(contexts, _setting.UnitSetting.CharacterSetting))
				.Add(new CharacterIconCreatingSystem(contexts, CharacterSelectSlideMenu))
				.Add(new ContextsResetSystem(contexts));

			if (IsServer())
			{
				systems.Add(new PlayerMissionAssignSystem(contexts, _setting.MissionSetting.PlayerMission));
			}

			return systems;
		}

		protected abstract bool IsServer();
	}
}
