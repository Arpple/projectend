using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Network
{
	[RequireComponent(typeof(IPlayerLoader))]
	public abstract class SceneLoader : MonoBehaviour
	{
		protected List<Player> _players;
		protected Player _localPlayer;
		protected IPlayerLoader _playerLoader;

		private LoadingScreen _loadingScreen;
		private bool _isReady;

		[Inject]
		public void Construct(LoadingScreen loadingScreen)
		{
			_loadingScreen = loadingScreen;
		}

		public bool IsReady()
		{
			return _isReady;
		}

		protected void SetReady()
		{
			_isReady = true;
			_loadingScreen.Hide();
		}

		protected virtual void Awake()
		{
			_playerLoader = GetComponent<IPlayerLoader>();
			_isReady = false;
		}

		protected virtual void Start()
		{
			_loadingScreen.Show();
			LoadPlayer();
			SetupPlayers();
			OnSetupComplete();
		}

		private void LoadPlayer()
		{
			_players = _playerLoader.GetAllPlayer();
			_localPlayer = _playerLoader.GetLocalPlayer();
		}

		private void SetupPlayers()
		{
			foreach (var player in _players)
			{
				SetupPlayer(player);
			}

			SetupLocalPlayer(_localPlayer);
		}

		protected virtual void SetupPlayer(Player player) { }
		protected virtual void SetupLocalPlayer(Player player) { }
		protected virtual void OnSetupComplete() { }
	}
}