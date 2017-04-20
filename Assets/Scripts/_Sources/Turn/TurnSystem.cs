using Offline;

public class TurnSystems : Feature
{
	public TurnSystems(Contexts contexts, GameUI ui, SystemController syscon) : base("Turn System")
	{
		Add(new PlayingOrderSetupSystem(contexts));
		Add(new TurnAndRoundSetupSystem(contexts));
		Add(new RoundLimitSetupSystem(contexts));
		Add(new RoundLimitGameEndSystem(contexts));
		Add(new RoundEndPlayingOrderReOrderingSystem(contexts));
		Add(new PlayingFlagSystem(contexts));
		Add(new TurnNodeCreatingSystem(contexts, ui.TurnPanel));
		Add(new TurnPanelPlayingOrderSystem(contexts, ui.TurnPanel));
		Add(new TurnNotificationSystem(contexts, ui.TurnNoti));
		Add(new TurnPanelRoundDisplaySystem(contexts, ui.TurnPanel));
		Add(new CurrentPlayerTurnIconSystem(contexts));
		Add(new LocalFlagPassingSystem(contexts, syscon));
		Add(new LocalPlayerPlayingStatusSystem(contexts, ui.LocalPlayerStatus));
	}
}