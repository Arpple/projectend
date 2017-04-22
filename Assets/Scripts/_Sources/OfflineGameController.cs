using System.Linq;
using Network;

public class OfflineGameController : GameController
{
	public override bool IsNetwork
	{
		get
		{
			return false;
		}
	}

	protected override void SetupPlayers()
	{
		var players = PlayerContainer.GetComponentsInChildren<Player>(true);
		AddLocalPlayer(players.First());
		players.Length.Loop(i =>
		{
			players[i].PlayerId = (short)(i + 1);
			AddPlayer(players[i]);
		});

		_playerLoader = new ClientPlayerLoader();
		var pl = _playerLoader as ClientPlayerLoader;
		pl.SetReady();

		Initialize();
	}
}