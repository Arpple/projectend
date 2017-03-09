using System.Collections;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

namespace End
{
	public class GameController : MonoBehaviour
	{
		public static GameController Instance;

		public static bool IsOffline
		{
			get { return Instance.IsOfflineMode; }
		}

		[Header("Test")]
		public bool IsOfflineMode = false;

		[Header("Config")]
		public GameSetting Setting;

		private Systems _systems;
		private Contexts _contexts;

		void Awake()
		{
			Instance = this;
		}

		void Start()
		{
			_contexts = Contexts.sharedInstance;
			_contexts.SetAllContexts();
			_systems = CreateSystems(_contexts);
			_systems.Initialize();
		}

		void Update()
		{
			Assert.IsTrue(_systems != null);

			_systems.Execute();
			_systems.Cleanup();
		}

		void OnDestory()
		{
			Assert.IsTrue(_systems != null);

			_systems.TearDown();
		}

		Systems CreateSystems(Contexts contexts)
		{
			return new Feature("Systems")
				.Add(new MapSystem(contexts, Setting.MapSetting.GameMap, Setting.MapSetting))
				.Add(new TileGraphSystem(contexts))

				.Add(new LoadResourceSystem(contexts))
				.Add(new RenderTileSystem(contexts, Setting.MapSetting.TileSetting))
				.Add(new TileActionSystem(contexts))

				.Add(new RenderMapPositionSystem(contexts))

				.Add(new CameraSystem(contexts))
				.Add(new CameraKeyboardSystem(contexts));
		}
	}
}
