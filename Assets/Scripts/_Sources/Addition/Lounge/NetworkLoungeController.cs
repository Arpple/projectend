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
			_networkController.ServerSceneChangedCallback = SetServerCallback;
			_networkController.ClientSceneChangedCallback = SendSceneReady;
			_networkController.OnAllPlayerReadyCallback += LoadGameScene;
		}

		private void OnDestroy()
		{
			var netCon = NetworkController.Instance;

			netCon.ServerSceneChangedCallback = null;
			netCon.ClientSceneChangedCallback = null;
			netCon.OnAllPlayerReadyCallback -= LoadGameScene;
		}

		public override void SetLocalPlayer(Player player)
		{
			base.SetLocalPlayer(player);
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

		protected void SetServerCallback()
		{
			_localPlayer.OnAllPlayerSceneLoadedCallback = SetStatusReady;
		}

		protected void SendSceneReady()
		{
			_localPlayer.CmdSendMessageSceneLoaded();
		}
	}
}
