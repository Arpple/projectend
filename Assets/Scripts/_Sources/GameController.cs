using System.Collections.Generic;
using Entitas;
using Entitas.VisualDebugging.Unity;
using Network;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public abstract class GameController : MonoBehaviour
{
	public static GameController Instance;
	public static bool IsTest;

	[Header("Config")]
	public SystemController SystemController;

	[Header("Data")]
	private Setting _setting;

	[Header("Object Container")]
	public GameObject PlayerContainer;
	public GameObject TileContainer;
	public GameObject UnitContainer;

	public abstract bool IsNetwork { get; }

	[HideInInspector] public List<Player> Players;
	protected Systems _systems;
	protected Contexts _contexts;
	protected bool _isInitialized;
	protected Player _localPlayer;
	protected PlayerLoader _playerLoader;

	[Inject]
	public void Construct(Setting setting)
	{
		_setting = setting;
	}

	private void Awake()
	{
		Instance = this;
		_isInitialized = false;
		Players = new List<Player>();

		PlayerContainer = PlayerContainer ?? new GameObject("Player");
		TileContainer = TileContainer ?? new GameObject("Tile");
		UnitContainer = UnitContainer ?? new GameObject("Unit");
	}

	private void Start()
	{
		Debug.Log("Start");
		ClearOldEntitySystem();
		CreateEntitySystem();

		SetupPlayers();
	}

	private void ClearOldEntitySystem()
	{
		foreach (var observer in FindObjectsOfType<ContextObserverBehaviour>())
		{
			Destroy(observer.gameObject);
		}
	}

	private void CreateEntitySystem()
	{
		_contexts = Contexts.sharedInstance;
		new EntityIdGenerator(_contexts);
	}

	protected abstract void SetupPlayers();

	protected void Initialize()
	{
		Debug.Log("Initialize");

		_systems = CreateSystem(_contexts);
		_systems.Initialize();
		_isInitialized = true;	
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
			.Add(new GameSystems(contexts, Players, _localPlayer))
			.Add(new TileSystems(contexts, _setting.TileSetting, TileContainer, GameUI.Instance))
			.Add(new UnitSystems(contexts, _setting.UnitSetting, UnitContainer, GameUI.Instance, SystemController))
			.Add(new CardSystems(contexts, _setting.CardSetting, GameUI.Instance))
			.Add(new TurnSystems(contexts, GameUI.Instance, SystemController))
			.Add(new WeatherSystems(contexts, _setting, GameUI.Instance))
			.Add(new BuffSystems(contexts, _setting, GameUI.Instance));
	}


	protected void AddPlayer(Player player)
	{
		Players.Add(player);
	}

	protected void AddLocalPlayer(Player player)
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
}