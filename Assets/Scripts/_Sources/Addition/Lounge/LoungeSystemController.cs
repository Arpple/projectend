using System.Collections.Generic;
using Entitas;
using Network;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Lounge
{
	public class LoungeSystemController : MonoBehaviour
	{
		public static LoungeSystemController Instance;

		private Systems _systems;
		private Contexts _contexts;
		private bool _isInit;
		private Setting _setting;
		protected PlayerLoader _playerLoader;

		[Inject]
		public void Construct(Setting setting)
		{
			_setting = setting;
		}

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(_setting);

			_isInit = false;
		}

		public void Start()
		{
			_contexts = Contexts.sharedInstance;
			Initialize();
		}

		public void Initialize()
		{
			_systems = CreateSystems(_contexts);

			_systems.Initialize();
			_isInit = true;
		}

		private void Update()
		{
			if (!_isInit) return;
			if (!LoungeController.Instance.IsReady()) return;

			_systems.Execute();
			_systems.Cleanup();
		}

		private void OnDestroy()
		{
			_systems.ClearReactiveSystems();
			_systems.TearDown();
		}

		Systems CreateSystems(Contexts contexts)
		{
			var players = GetAllPlayers();

			var systems = new Feature("Systems")
				.Add(new PlayerCreatingSystem(contexts, players))
				.Add(new LocalPlayerSetupSystem(contexts, LoungeController.Instance.GetLocalPlayer()))
				.Add(new CharacterLoadingSystems(contexts))
				.Add(new CharacterDataLoadingSystem(contexts, _setting.UnitSetting.CharacterSetting))
				.Add(new CharacterIconCreatingSystem(contexts, LoungeController.Instance.CharacterSelectSlideMenu))
				.Add(new ContextsResetSystem(contexts));

			if (IsServer())
			{
				systems.Add(new PlayerMissionAssignSystem(contexts, _setting.MissionSetting.PlayerMission));
			}

			return systems;
		}

		private bool IsServer()
		{
			return (NetworkController.Instance != null && NetworkController.IsServer);
		}

		private List<Player> GetAllPlayers()
		{
			return LoungeController.Instance.GetAllPlayers();
		}
	}

}
