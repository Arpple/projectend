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

		public static Player LocalPlayer
		{
			get; private set;
		}

		[Header("Test")]
		public bool IsOfflineMode = false;

		[Header("Config")]
		public GameSetting Setting;
		public GameObject PlayerContainer;

		[HideInInspector]
		public bool IsOffline{ get { return IsOfflineMode; } }

		private Systems _systems;
		private Contexts _contexts;
		private bool _isInitialized;
		private List<Player> _players;
		private int _playerCount;

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
			_systems = CreateSystem(_contexts);

			if(IsOfflineMode)
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
				.Add(new MapSystem(contexts, Setting.MapSetting.GameMap.Load(), Setting.MapSetting))
				.Add(new TileGraphSystem(contexts))
				.Add(new SetupActionButtonSystem(contexts))
				.Add(new InitializePlayerSystem(contexts, _players))
				.Add(new LoadPlayerDeckSystem(contexts))
				.Add(new LoadCardDeckSystem(contexts, Setting.DeckSetting.CardSetting.Deck))

				.Add(new LoadCharacterSystem(contexts, Setting.UnitSetting.CharacterSetting))
				.Add(new LoadCardSystem(contexts, Setting.DeckSetting.CardSetting))
				.Add(new LoadResourceSystem(contexts))
				.Add(new ViewContainerSystem(contexts))
				.Add(new TileActionSystem(contexts))

				.Add(new RenderMapPositionSystem(contexts))

				.Add(new CameraSystem(contexts))
				.Add(new CameraKeyboardSystem(contexts))

				.Add(new ClearContextsSystem(contexts));
		}

		private void SetupNetworkOffline()
		{
			var players = PlayerContainer.GetComponentsInChildren<Player>(true);
			_playerCount = players.Length;
			players.Length.Loop(i =>
			{
				players[i].PlayerId = (short)(i + 1);
				AddPlayer(players[i]);
			});
			LocalPlayer = players.First();
		}

		#region Network

		public void SetupNetwork()
		{
			var netCon = NetworkController.Instance;
			netCon.OnClientPlayerStartCallback += AddPlayer;
			netCon.OnLocalPlayerStartCallback += AddLocalPlayer;
			_playerCount = netCon.ConnectionCount;
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
			LocalPlayer = player;
		}
		#endregion
	}
}
