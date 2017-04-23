using Network;

public class NetworkGameController : GameController
{
	public override bool IsNetwork
	{
		get
		{
			return true;
		}
	}

	protected override void SetupPlayers()
	{
		var netCon = NetworkController.Instance;

		foreach (var player in netCon.AllPlayers)
		{
			AddPlayer(player);
		}

		AddLocalPlayer(netCon.LocalPlayer);
		netCon.ClientSceneChangedCallback = InitializeAndSetReady;
		_localPlayer.OnAllPlayerSceneLoadedCallback = SetStatusReady;
	}

	protected void InitializeAndSetReady()
	{
		Initialize();
		_localPlayer.CmdSendMessageSceneLoaded();
	}
}