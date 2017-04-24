using System.Collections.Generic;
using Entitas;
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
		public void Construct(Setting setting, Contexts contexts)
		{
			_setting = setting;
			_contexts = contexts;
		}

		private void Awake()
		{
			_ui = GetComponent<ResultUIController>();
			_players = new List<Player>();
		}

		protected virtual void Start()
		{
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
			_systems.ClearReactiveSystems();
			_systems.DeactivateReactiveSystems();
			_contexts.Reset();
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

		private void Initialize()
		{
			_contexts.ResetContextObserver();
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
