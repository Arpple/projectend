using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;
using End.Game.UI;
using Entitas.Unity.VisualDebugging;

namespace End.Game
{
	public class GameController : MonoBehaviour
	{
		public static GameController Instance;
		public static bool IsTest;

		[Header("Test")]
		public bool IsOffline = false;

		[Header("Config")]
		public GameSetting Setting;
		public GameObject PlayerContainer;

		private Systems _systems;
		private Contexts _contexts;
		private bool _isInitialized;
		private List<Player> _players;
		private Player _localPlayer;

		void Awake()
		{
			Instance = this;
			_isInitialized = false;
			_players = new List<Player>();

			Assert.IsNotNull(Setting);
			Assert.IsNotNull(PlayerContainer);
		}

		void Start()
		{
			Debug.Log("Start");
			//clear old observer
			foreach(var observer in FindObjectsOfType<ContextObserverBehaviour>())
			{
				Destroy(observer.gameObject);
			}

			new GameUtil();

			//create entitas system
			_contexts = Contexts.sharedInstance;
			_contexts.SetAllContexts();

			if (IsOffline)
			{
				SetupNetworkOffline();
				Initialize();
				Debug.Log("Offline Init");
			}
			else
			{
				SetupNetwork();
			}
		}

		private void Initialize()
		{
			Debug.Log("Initialize");
			
			_systems = CreateSystem(_contexts);
			_systems.Initialize();
			_isInitialized = true;
		}

		void Update()
		{
			if (!_isInitialized) return;
			Assert.IsNotNull(_systems);

			_systems.Execute();
			_systems.Cleanup();
		}

		void OnDestory()
		{
			Assert.IsNotNull(_systems);

			_systems.ClearReactiveSystems();
			_systems.TearDown();
		}

		public Systems CreateSystem(Contexts contexts)
		{
			return new Feature("Systems")
				
				.Add(new GameSetupSystem(contexts, Setting, _players, _localPlayer))
				.Add(new DataLoadingSystem(contexts, Setting))
				.Add(new DataRenderingSystem(contexts, GameUI.Instance))
		
				.Add(new ViewContainerSystem(contexts))
				.Add(new GameEventFeature(contexts))

				.Add(new ControlSystem(contexts))
				.Add(new ClearContextsSystem(contexts));
		}

		#region Network

		public void SetupNetwork()
		{
			var netCon = NetworkController.Instance;

			foreach (var player in netCon.AllPlayers)
			{
				AddPlayer(player);
			}

			AddLocalPlayer(netCon.LocalPlayer);
			netCon.ClientSceneChangedCallback = Initialize;
		}

		private void SetupNetworkOffline()
		{
			var players = PlayerContainer.GetComponentsInChildren<Player>(true);
			AddLocalPlayer(players.First());
			players.Length.Loop(i =>
			{
				players[i].PlayerId = (short)(i + 1);
				AddPlayer(players[i]);
			});
		}

		public void AddPlayer(Player player)
		{
			_players.Add(player);
		}

		public void AddLocalPlayer(Player player)
		{
			_localPlayer = player;
		}
		#endregion
	}
}
