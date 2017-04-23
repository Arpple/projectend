using System.Collections.Generic;
using UnityEngine;

namespace Network
{
	[RequireComponent(typeof(IPlayerLoader))]
	public abstract class SceneLoader : MonoBehaviour
	{
		protected List<Player> _players;
		protected Player _localPlayer;
		protected IPlayerLoader _playerLoader;

		private bool _isReady;

		public bool IsReady()
		{
			return _isReady;
		}

		protected void SetReady()
		{
			_isReady = true;
		}

		protected virtual void Awake()
		{
			_playerLoader = GetComponent<IPlayerLoader>();
			_isReady = false;
		}

		protected virtual void Start()
		{
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