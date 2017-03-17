using Entitas;
using UnityEngine;

namespace End.CharacterSelect
{
	public class Controller : MonoBehaviour
	{
		public Controller Instance;

		private Systems _systems;
		private Contexts _contexts;
		private bool _isInit;

		private void Awake()
		{
			Instance = this;
			_isInit = false;
		}

		public void Start()
		{
			var netCon = NetworkController.Instance;
			netCon.OnAllPlayerReadyCallback += Initialize;
			_contexts = Contexts.sharedInstance;
			
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
				.Add(new Game.ClearContextsSystem(contexts));
		}
	}

}
