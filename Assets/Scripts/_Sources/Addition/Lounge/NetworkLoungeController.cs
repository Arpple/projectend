using Network;

namespace Lounge
{
	public class NetworkLoungeController : LoungeController
	{
		private NetworkController _netCon
		{
			get { return NetworkController.Instance; }
		}

		protected override void Start()
		{
			base.Start();
			_netCon.OnAllPlayerReadyCallback = LoadGameScene;
		}

		protected override void LockFocusingCharacter()
		{
			_localPlayer.CmdSetCharacterId((int)_focusingCharacter);
		}

		private void LoadGameScene()
		{
			_netCon.ServerResetPlayerReadyStatus();
			_netCon.ServerChangeScene(GameScene.Game.ToString());
		}

		protected override bool IsServer()
		{
			return NetworkController.IsServer;
		}
	}
}
