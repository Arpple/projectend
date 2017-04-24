using System.Collections.Generic;
using Entitas;
using Entitas.VisualDebugging.Unity;
using Network;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

public class GameController : MonoBehaviour
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

	public bool IsNetwork
	{
		get { return _playerLoader.IsNetwork(); }
	}

	protected Systems _systems;
	protected Contexts _contexts;
	protected bool _isInitialized;
	protected IPlayerLoader _playerLoader;
	protected SceneLoader _sceneLoader;

	[Inject]
	public void Construct(Setting setting)
	{
		_setting = setting;
	}

	private void Awake()
	{
		Instance = this;

		_isInitialized = false;
		_playerLoader = GetComponent<IPlayerLoader>();
		_sceneLoader = GetComponent<SceneLoader>();

		PlayerContainer = PlayerContainer ?? new GameObject("Player");
		TileContainer = TileContainer ?? new GameObject("Tile");
		UnitContainer = UnitContainer ?? new GameObject("Unit");
	}

	protected virtual void Start()
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

	protected virtual void SetupPlayers()
	{ }

	protected void Initialize()
	{
		Debug.Log("Initialize");

		_systems = CreateSystem(_contexts);
		_systems.Initialize();
		_isInitialized = true;	
	}

	void Update()
	{
		if (!_sceneLoader.IsReady()) return;
		if(!_isInitialized)
		{
			Initialize();
		}
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
			.Add(new GameSystems(contexts, GetAllPlayers(), GetLocalPlayer()))
			.Add(new TileSystems(contexts, _setting.TileSetting, TileContainer, GameUI.Instance))
			.Add(new UnitSystems(contexts, _setting.UnitSetting, UnitContainer, GameUI.Instance, SystemController))
			.Add(new CardSystems(contexts, _setting.CardSetting, GameUI.Instance))
			.Add(new TurnSystems(contexts, GameUI.Instance, SystemController))
			.Add(new WeatherSystems(contexts, _setting, GameUI.Instance))
			.Add(new BuffSystems(contexts, _setting, GameUI.Instance))
			.Add(new GameEventSystems(contexts));
	}

	protected List<Player> GetAllPlayers()
	{
		return _playerLoader.GetAllPlayer();
	}

	protected Player GetLocalPlayer()
	{
		return _playerLoader.GetLocalPlayer();
	}
}
