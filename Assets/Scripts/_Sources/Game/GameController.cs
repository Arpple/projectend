using System.Collections;
using System.Collections.Generic;
using Entitas;
using Network;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
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

	public bool IsNetwork()
	{
		return _playerLoader.IsNetwork();
	}

	public bool IsServer()
	{
		return !IsNetwork() || NetworkController.IsServer;
	}

	protected Systems _systems;
	protected Contexts _contexts;
	protected bool _isInitialized;
	protected bool _isStart;
	protected bool _isGameEnd;
	protected IPlayerLoader _playerLoader;
	protected SceneLoader _sceneLoader;

	private Player _localPlayer;

	[Inject]
	public void Construct(Setting setting, Contexts contexts)
	{
		_setting = setting;
		_contexts = contexts;
	}

	private void Awake()
	{
		Instance = this;

		_isInitialized = false;
		_isGameEnd = false;
		_isStart = false;
		_playerLoader = GetComponent<IPlayerLoader>();
		_sceneLoader = GetComponent<SceneLoader>();

		PlayerContainer = PlayerContainer ?? new GameObject("Player");
		TileContainer = TileContainer ?? new GameObject("Tile");
		UnitContainer = UnitContainer ?? new GameObject("Unit");
	}

	protected virtual void Start()
	{
		Debug.Log("Start");
		SetupPlayers();
	}

	protected virtual void SetupPlayers()
	{
		_localPlayer = _playerLoader.GetLocalPlayer();
		_localPlayer.AllPlayerGameInitAction = StartGame;
	}

	protected void Initialize()
	{
		Debug.Log("Initialize");
		_isInitialized = true;
		new EntityIdGenerator(_contexts);
		_contexts.ResetContextObserver();
		_systems = CreateSystem(_contexts);
		_systems.Initialize();
		FinishInit();
	}

	void Update()
	{
		if (!_sceneLoader.IsReady()) return;
		if(!_isInitialized)
		{
			Initialize();
			return;
		}
		if (!_isStart) return;
		Assert.IsNotNull(_systems);

		_systems.Execute();
		_systems.Cleanup();

		if(_isGameEnd)
		{
			EndGame();
		}
	}

	void OnDestroy()
	{
		_systems.TearDown();
		_systems.DeactivateReactiveSystems();
		_systems.ClearReactiveSystems();
		_contexts.Reset();
	}

	public Systems CreateSystem(Contexts contexts)
	{
		return new Feature("Systems")
			.Add(new InputSystems(contexts))
			.Add(new GameSystems(contexts, GetAllPlayers(), GetLocalPlayer()))
			.Add(new TileSystems(contexts, _setting.TileSetting, TileContainer, GameUI.Instance))
			.Add(new UnitSystems(contexts, _setting.UnitSetting, UnitContainer, GameUI.Instance, SystemController))
			.Add(new CardSystems(contexts, _setting.CardSetting, GameUI.Instance, IsServer()))
			.Add(new TurnSystems(contexts, GameUI.Instance, SystemController))
			.Add(new WeatherSystems(contexts, _setting, GameUI.Instance, SystemController))
			.Add(new BuffSystems(contexts, _setting, GameUI.Instance))
			.Add(new MissionSystems(contexts, GameUI.Instance))
			.Add(new GameEventSystems(contexts))
			.Add(new EventGameEndSystem(contexts, SetGameEnd));
	}

	protected List<Player> GetAllPlayers()
	{
		return _playerLoader.GetAllPlayer();
	}

	protected Player GetLocalPlayer()
	{
		return _playerLoader.GetLocalPlayer();
	}

	private void FinishInit()
	{
		if(_playerLoader.IsNetwork())
		{
			StartCoroutine(SendGameInit());
		}
		else
		{
			StartGame();
		}
	}

	private void StartGame()
	{
		_isStart = true;
	}

	private void SetGameEnd()
	{
		_isGameEnd = true;
	}

	private void EndGame()
	{
		SceneManager.LoadScene(GameScene.Result.ToString());
	}

	IEnumerator SendGameInit()
	{
		while(!_isStart)
		{
			_localPlayer.CmdSendGameInit();
			yield return new WaitForSeconds(0.5f);
		}
	}
}
