using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

using Entitas.VisualDebugging.Unity;
using Network;

public class GameController : MonoBehaviour
{
	public static GameController Instance;
	public static bool IsTest;

	[Header("Test")]
	public bool IsOffline = false;

	[Header("Config")]
	public Setting Setting;

	[Header("Object Container")]
	public GameObject PlayerContainer;
	public GameObject TileContainer;
	public GameObject UnitContainer;

	[HideInInspector] public List<Player> Players;
	private Systems _systems;
	private Contexts _contexts;
	private bool _isInitialized;
	private Player _localPlayer;
	private PlayerLoader _playerLoader;

	void Awake()
	{
		Instance = this;
		_isInitialized = false;
		Players = new List<Player>();

		Assert.IsNotNull(Setting);
		PlayerContainer = PlayerContainer ?? new GameObject("Player");
		TileContainer = TileContainer ?? new GameObject("Tile");
		UnitContainer = UnitContainer ?? new GameObject("Unit");
	}

	void Start()
	{
		Debug.Log("Start");
		//clear old observer
		foreach (var observer in FindObjectsOfType<ContextObserverBehaviour>())
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

		if (!IsOffline)
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
			.Add(new InputSystems(contexts))
			.Add(new GameEventSystems(contexts))
			.Add(new GameSystems(contexts, Players, _localPlayer, GameUI.Instance))
			.Add(new TileSystems(contexts, Setting.TileSetting, TileContainer, GameUI.Instance))
			.Add(new UnitSystems(contexts, Setting.UnitSetting, UnitContainer, GameUI.Instance))
			.Add(new CardSystems(contexts, Setting.CardSetting, GameUI.Instance));
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

		if (NetworkController.IsServer)
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
		Players.Add(player);
	}

	public void AddLocalPlayer(Player player)
	{
		_localPlayer = player;
	}

	public void ServerLoadPlayer()
	{
		var pl = _playerLoader as ServerPlayerLoader;
		if (pl != null)
		{
			pl.LoadPlayer();
		}
		if (_playerLoader.IsReady())
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