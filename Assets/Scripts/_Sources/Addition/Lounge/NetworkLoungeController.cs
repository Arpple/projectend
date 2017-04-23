using System.Collections.Generic;
using Network;

namespace Lounge
{
	public class NetworkLoungeController : LoungeController
	{
		private NetworkController _networkController
		{
			get { return NetworkController.Instance; }
		}

		protected override void Start()
		{
			base.Start();
			_networkController.ServerSceneChangedCallback = _networkController.LocalPlayer.RpcResetReadyStatus;
			_networkController.OnAllPlayerReadyCallback += LoadGameScene;
		}

		private void OnDestroy()
		{
			var netCon = NetworkController.Instance;

			netCon.ServerSceneChangedCallback = null;
			netCon.OnAllPlayerReadyCallback -= LoadGameScene;
		}

		public override List<Player> GetAllPlayers()
		{
			return _networkController.AllPlayers;
		}

		public override Player GetLocalPlayer()
		{
			return _networkController.LocalPlayer;
		}

		protected override void LockFocusingCharacter()
		{
			_localPlayer.CmdSetCharacterId((int)_focusingCharacter);
		}
	}
}
