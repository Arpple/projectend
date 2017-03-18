using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

namespace End.Game.CharacterSelect
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
			_contexts.SetAllContexts();
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
			_systems.TearDown();
		}

		Systems CreateSystems(Contexts contexts)
		{
			return new Feature("Systems")
				.Add(new LoadAllCharacterSystems(contexts, Setting.UnitSetting.CharacterSetting))
				.Add(new LoadCharacterIconSystem(contexts, Setting.UnitSetting.CharacterSetting))
				.Add(new ClearContextsSystem(contexts));
		}
	}

}
