using Entitas;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace End.Game
{
	public class GameController : MonoBehaviour
	{
		public static GameController Instance;

		public static bool IsOffline
		{
			get { return Instance.IsOfflineMode; }
		}

		public static Player LocalPlayer
		{
			get; private set;
		}

		[Header("Test")]
		public bool IsOfflineMode = false;

		[Header("Config")]
		public GameSetting Setting;
		public GameObject PlayerContainer;

		private Systems _systems;
		private Contexts _contexts;
		private bool _isInitialized;
		private List<Player> _players;

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
			//create entitas system
			_contexts = Contexts.sharedInstance;
			_contexts.SetAllContexts();
			_systems = CreateSystems(_contexts);

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
			Assert.IsTrue(_systems != null);
			if (!_isInitialized) return;

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
				.Add(new MapSystem(contexts, Setting.MapSetting.GameMap.Load(), Setting.MapSetting))
				.Add(new TileGraphSystem(contexts))
				//.Add(new InitializePlayerSystem(contexts, PlayerLoader.Instance.PlayerList))

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
			NetworkController.Instance.ConnectionCount = players.Length;
			foreach (var player in players)
			{
				AddPlayer(player);
			}
		}

		#region Network

		public void SetupNetwork()
		{
			var netCon = NetworkController.Instance;
			netCon.OnClientPlayerStartCallback += AddPlayer;
		}

		public void AddPlayer(Player player)
		{
			_players.Add(player);
			player.transform.SetParent(PlayerContainer.transform);

			//start game if all player connected
			var playerCount = NetworkController.Instance.ConnectionCount;
			Assert.AreNotEqual(0, playerCount);
			if (_players.Count == playerCount)
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
