﻿using Offline;

public class TurnSystems : Feature
{
	public TurnSystems(Contexts contexts, GameUI ui, SystemController syscon) : base("Turn System")
	{
		Add(new PlayingOrderSetupSystem(contexts));
		Add(new TurnAndRoundSetupSystem(contexts));
		Add(new RoundEndPlayingOrderReOrderingSystem(contexts));
		Add(new PlayingFlagSystem(contexts));
		Add(new TurnNodeCreatingSystem(contexts, ui.TurnPanel));
		Add(new TurnPanelSystem(contexts, ui.TurnPanel));
		Add(new TurnNotificationSystem(contexts, ui.TurnNoti));

		Add(new LocalFlagPassingSystem(contexts, syscon));
	}
}