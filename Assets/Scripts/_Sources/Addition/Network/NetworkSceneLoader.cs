namespace Network
{
	public class NetworkSceneLoader : SceneLoader
	{
		private bool _isSetup;

		protected override void Awake()
		{
			base.Awake();
			_isSetup = false;
		}

		protected override void SetupLocalPlayer(Player player)
		{
			_localPlayer.AllPlayerSceneLoadedAction = SetReady;
		}

		private void Update()
		{
			if (IsReady()) return;
			if (!_isSetup) return;
			_localPlayer.CmdSendMessageSceneLoaded();
		}

		protected override void OnSetupComplete()
		{
			_isSetup = true;
		}
	} 
}