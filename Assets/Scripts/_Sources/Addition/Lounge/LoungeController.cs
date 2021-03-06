﻿using Entitas;
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
	public abstract class LoungeController : MonoBehaviour
	{
		public static LoungeController Instance;

		public UnitStatusPanel UnitStatus;
		public UnitSkillPanel UnitSkill;
		public GameObject CharacterContent, PlayerListContent;
		public SlideMenu CharacterSelectSlideMenu;
		public Button LockButton;
		public LoungePlayer CharacterSelectPlayerPrefabs;
		public MissionBookController MissionBook;
		public RoundDisplay RoundLimit;

		protected Setting _setting;
		protected Character _focusingCharacter;
		protected Player _localPlayer;
		protected SceneLoader _sceneLoader;

		private IPlayerLoader _playerLoader;
		private Systems _systems;
		private Contexts _contexts;
		private bool _isInit;

		protected abstract bool IsServer();

		[Inject]
		public void Construct(Setting setting, Contexts contexts)
		{
			_setting = setting;
			_contexts = contexts;
		}

		private void Awake()
		{
			Instance = this;

			_playerLoader = GetComponent<IPlayerLoader>();
			_sceneLoader = GetComponent<SceneLoader>();
		}

		protected virtual void Start()
		{
			_localPlayer = _playerLoader.GetLocalPlayer();
			MissionBook.LoadData(_setting.MissionSetting);
			UnitSkill.LoadData(_setting.CardSetting.SkillCardSetting);

			LockButton.onClick.AddListener(LockFocusingCharacter);
			CharacterSelectSlideMenu.OnFocusItemChangedCallback += FocusCharacterIcon;

			SetupSystems();

			foreach (var p in _playerLoader.GetAllPlayer())
			{
				p.ResetAction();
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
			_systems.TearDown();
			_systems.DeactivateReactiveSystems();
			_systems.ClearReactiveSystems();
			_contexts.Reset();
		}

		protected abstract void LockFocusingCharacter();

		private void FocusCharacterIcon(SlideItem characterIcon)
		{
			var entity = (UnitEntity)characterIcon.gameObject.GetEntityLink().entity;
			_focusingCharacter = entity.character.Type;

			ShowUnitInformationUnit(entity);
		}

		public void ShowUnitInformationUnit(UnitEntity unit)
		{
			UnitStatus.SetUnit(unit);
			UnitSkill.SetUnit(unit);
		}

		private void SetupPlayer(Player player)
		{
			LoungePlayer charPlayer = Instantiate(CharacterSelectPlayerPrefabs, PlayerListContent.transform, false);
			charPlayer.SetPlayer(player);
			player.CharacterUpdateAction += DisableCharacterIcon;
			player.PlayerMissionUpdateAction += MissionBook.SetLocalPlayerMission;
			player.MissionTargetUpdateAction += MissionBook.SetLocalPlayerTarget;
		}

		private void DisableCharacterIcon(Character character)
		{
			Assert.AreNotEqual(Character.None, character);

			//var item = CharacterSelectSlideMenu.SlideItems.First(i =>
			//{
			//	var entity = (UnitEntity)i.gameObject.GetEntityLink().entity;
			//	return entity.character.Type == character;
			//});

			//TODO: disable 'item'
			//Debug.Log("disable " + item);
		}

		protected virtual void SetupLocalPlayer(Player player)
		{
			player.CharacterUpdateAction += OnLocalPlayerCharacterSelected;
			MissionBook.SetLocalMainMission((MainMission)player.MainMissionId);
		}

		private  void OnLocalPlayerCharacterSelected(Character characterId)
		{
			LockButton.interactable = false;
		}

		#region System
		private void SetupSystems()
		{
			_contexts.ResetContextObserver();
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
				.Add(new RoundLimitDisplaySystem(contexts, RoundLimit))
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
		#endregion
	}
}
