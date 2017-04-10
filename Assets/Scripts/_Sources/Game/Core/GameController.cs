using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;
using Game.UI;
using Entitas.VisualDebugging.Unity;

namespace Game
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
		private PlayerLoader _playerLoader;

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

			//create entitas system
			_contexts = Contexts.sharedInstance;
			new EntityIdGenerator(_contexts);

			if (IsOffline)
			{
				Debug.Log("Offline Init");
				SetupNetworkOffline();
				Initialize();
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

			if(!IsOffline)
				_localPlayer.CmdClientLoad();
		}

		void Update()
		{
			if (!_isInitialized) return;
			if (!_playerLoader.IsReady()) return;
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

				.Add(new GameSetupSystems(contexts, Setting, _players, _localPlayer))
				.Add(new DataLoadingSystems(contexts, Setting))
				.Add(new GameUISetupSystems(contexts, GameUI.Instance))

				.Add(new GameEventSystems(contexts))
				.Add(new DataRenderingSystems(contexts, Setting))
		
				.Add(new GameUIRenderingSystems(contexts, GameUI.Instance))

				.Add(new InputSystems(contexts))
				.Add(new ContextsResetSystem(contexts));
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

			if(NetworkController.IsServer)
			{
				_playerLoader = new ServerPlayerLoader(netCon.AllPlayers.Count);
			}
			else
			{
				_playerLoader = new ClientPlayerLoader();
			}
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

			_playerLoader = new ClientPlayerLoader();
			var pl = _playerLoader as ClientPlayerLoader;
			pl.SetReady();
		}

		public void AddPlayer(Player player)
		{
			_players.Add(player);
		}

		public void AddLocalPlayer(Player player)
		{
			_localPlayer = player;
		}

		public void ServerLoadPlayer()
		{
			var pl = _playerLoader as ServerPlayerLoader;
			if(pl != null)
			{
				pl.LoadPlayer();
			}
			if(_playerLoader.IsReady())
			{
				_localPlayer.RpcServerReady();
			}
		}

		public void SetClientReady()
		{
			var pl = _playerLoader as ClientPlayerLoader;
			if (pl != null)
			{
				pl.SetReady();
			}
		}
		#endregion
	}
}
