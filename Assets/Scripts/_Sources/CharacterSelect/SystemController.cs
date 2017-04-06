using Entitas;
using UnityEngine;
using UnityEngine.Assertions;
using Game;

namespace CharacterSelect
{
	public class SystemController : MonoBehaviour
	{
		public static SystemController Instance;

		public GameSetting Setting;

		private Systems _systems;
		private Contexts _contexts;
		private bool _isInit;

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(Setting);

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
			var players = NetworkController.Instance.AllPlayers;

			var systems = new Feature("Systems")
				.Add(new PlayerCreatingSystem(contexts, players))
				.Add(new LocalPlayerSetupSystem(contexts, NetworkController.Instance.LocalPlayer))
				.Add(new LoadAllCharacterSystems(contexts, Setting.UnitSetting.CharacterSetting))
				.Add(new CharacterIconLoadingSystem(contexts))
				.Add(new CreateCharacterSelectionIconSystem(contexts, CharacterSelectController.Instance.CharacterSelectSlideMenu))
				.Add(new ContextsResetSystem(contexts))
				;

			if (IsServer())
			{
				systems.Add(new RoleSetupSystem(contexts, Setting.RoleSetting.GetRolesCount(players.Count)));
				systems.Add(new RoleSavingSystem(contexts));
			}

			return systems;
		}

		private bool IsServer()
		{
			return (NetworkController.Instance != null && NetworkController.IsServer);
		}
	}

}
