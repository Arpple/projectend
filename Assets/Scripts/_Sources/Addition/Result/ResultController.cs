using Entitas;
using Network;
using UnityEngine;
using Zenject;

namespace Result
{
	[RequireComponent(typeof(ResultUIController), typeof(IPlayerLoader), typeof(SceneLoader))]
	public class ResultController : MonoBehaviour
	{
		ResultUIController _ui;

		private IPlayerLoader _playerLoader;

		protected Contexts _contexts;
		protected Systems _systems;
		protected Setting _setting;

		[Inject]
		public void Construct(Setting setting, Contexts contexts)
		{
			_setting = setting;
			_contexts = contexts;
		}

		private void Awake()
		{
			_ui = GetComponent<ResultUIController>();

			_playerLoader = GetComponent<IPlayerLoader>();
		}

		protected virtual void Start()
		{
			Initialize();
		}

		private void Update()
		{
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

		private void Initialize()
		{
			_contexts.ResetContextObserver();
			_systems = new Feature("Systems")
				.Add(new PlayerCreatingSystem(_contexts, _playerLoader.GetAllPlayer()))
				.Add(new LocalPlayerSetupSystem(_contexts, _playerLoader.GetLocalPlayer()))
				.Add(new LocalPlayerResultLoadingSystem(_contexts))
				.Add(new PlayerResultObjectCreatingSystem(_contexts, _setting, _ui))
				.Add(new LocalPlayerResultSystem(_contexts, _ui));

			_systems.Initialize();
		}
	}
}
