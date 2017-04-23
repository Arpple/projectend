using System;
using Network;
using UnityEngine;

namespace Lounge
{
	public class NetworkLoungeSceneController : LoungeSceneController
	{
		private NetworkController _netCon
		{
			get { return NetworkController.Instance; }
		}

		protected override void Start()
		{
			base.Start();
			_netCon.OnAllPlayerReadyCallback += LoadGameScene;
		}

		private void OnDestroy()
		{
			_netCon.OnAllPlayerReadyCallback -= LoadGameScene;
		}

		protected override void LockFocusingCharacter()
		{
			throw new NotImplementedException();
		}

		private void LoadGameScene()
		{
			_netCon.ServerResetSceneReadyStatus();
			_netCon.ServerChangeScene(GameScene.Game.ToString());
		}

		protected override bool IsServer()
		{
			return NetworkController.IsServer;
		}
	}
}
