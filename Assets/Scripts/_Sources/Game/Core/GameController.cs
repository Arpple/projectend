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
		private int _playerCount;
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
			//clear old observer
			foreach(var observer in FindObjectsOfType<ContextObserverBehaviour>())
			{
				Destroy(observer.gameObject);
			}

			//create entitas system
			_contexts = Contexts.sharedInstance;
			_contexts.SetAllContexts();
			
			if (IsOffline)
			{
				SetupNetworkOffline();
			}
			else
			{
				SetupNetwork();
			}
		}

		private void Initialize()
		{
			if(NetworkController.IsServer)
			{
				//setup player id
				short id = 1;
				foreach(var player in _players)
				{
					player.PlayerId = id;
					id++;
				}
			}
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
				.Add(new DataLoadingSystem(contexts, Setting))
				.Add(new GameSetupSystem(contexts, Setting, _players, _localPlayer))
				.Add(new CardSystem(contexts))

				.Add(new LoadCharacterSystem(contexts, Setting.UnitSetting.CharacterSetting))
				.Add(new ViewContainerSystem(contexts))
				.Add(new RenderMapPositionSystem(contexts))

				.Add(new GameEventFeature(contexts))

				.Add(new ControlSystem(contexts))
				.Add(new ClearContextsSystem(contexts));
		}

		#region Network

		public void SetupNetwork()
		{
			var netCon = NetworkController.Instance;
			netCon.OnClientPlayerStartCallback += AddPlayer;
			netCon.OnLocalPlayerStartCallback += AddLocalPlayer;
			_playerCount = netCon.ConnectionCount;
		}

		private void SetupNetworkOffline()
		{
			var players = PlayerContainer.GetComponentsInChildren<Player>(true);
			_playerCount = players.Length;
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
			player.transform.SetParent(PlayerContainer.transform);

			//start game if all player connected
			Assert.AreNotEqual(0, _playerCount);
			if (_players.Count == _playerCount)
			{
				Initialize();
			}
		}

		public void AddLocalPlayer(Player player)
		{
			_localPlayer = player;
		}
		#endregion
	}
}
