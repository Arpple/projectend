using Offline;

public class TurnSystems : Feature
{
	public TurnSystems(Contexts contexts, GameUI ui) : base("Turn System")
	{
		Add(new PlayingOrderSetupSystem(contexts));
		Add(new TurnAndRoundSetupSystem(contexts));
		Add(new RoundEndPlayingOrderReOrderingSystem(contexts));
		Add(new PlayingFlagSystem(contexts));
		Add(new TurnNodeCreatingSystem(contexts, ui.TurnPanel));
		Add(new TurnPanelSystem(contexts, ui.TurnPanel));
		Add(new TurnNotificationSystem(contexts, ui.TurnNoti));

		if (GameController.Instance.IsOffline)
		{
			Add(new LocalFlagPassingSystem(contexts));
		}
	}
}