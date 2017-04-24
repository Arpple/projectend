using System.Collections.Generic;
using Entitas;
using Entitas.VisualDebugging.Unity;
using Network;
using UnityEngine;
using Zenject;

namespace Result
{
	[RequireComponent(typeof(ResultUIController))]
	public abstract class ResultController : MonoBehaviour
	{
		[Header("Container")]
		public Transform PlayerParent;

		ResultUIController _ui;

		private List<Player> _players;
		protected Player _localPlayer;
		protected Contexts _contexts;
		protected Systems _systems;
		protected Setting _setting;

		[Inject]
		public void Construct(Setting setting)
		{
			_setting = setting;
		}

		private void Awake()
		{
			_ui = GetComponent<ResultUIController>();
			_players = new List<Player>();
		}

		protected virtual void Start()
		{
			ClearOldEntitySystem();
			CreateEntitySystem();
			SetupPlayers();
			Initialize();
		}

		private void Update()
		{
			_systems.Execute();
			_systems.Cleanup();
		}

		private void OnDestroy()
		{
			_systems.TearDown();
		}

		protected abstract void SetupPlayers();

		protected void AddPlayer(Player player)
		{
			_players.Add(player);
			player.transform.SetParent(PlayerParent);
		}

		protected void SetLocalPlayer(Player player)
		{
			_localPlayer = player;
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

		private void Initialize()
		{
			_systems = new Feature("Systems")
				.Add(new PlayerCreatingSystem(_contexts, _players))
				.Add(new LocalPlayerSetupSystem(_contexts, _localPlayer))
				.Add(new LocalPlayerResultLoadingSystem(_contexts))
				.Add(new PlayerResultObjectCreatingSystem(_contexts, _setting, _ui))
				.Add(new LocalPlayerResultSystem(_contexts, _ui));

			_systems.Initialize();
		}
	}
}
