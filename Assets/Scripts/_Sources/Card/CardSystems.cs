public class CardSystems : Feature
{
	public CardSystems(Contexts contexts, CardSetting setting, GameUI ui) : base("Card System")
	{
		Add(new DeckCardCreatingSystem(contexts, setting.DeckSetting.Deck));
		Add(new CardDataLoadingSystem(contexts, setting));
		Add(new CardViewCreatingSystem(contexts, setting));

		CreateDeckCardSystems(contexts, setting.DeckSetting, ui);
		CreateBoxCardSystems(contexts, ui);
		CreateSkillCardSystems(contexts, ui);

		Add(new ResourceCardDestroySystem(contexts));
	}

	private void CreateDeckCardSystems(Contexts contexts, DeckSetting setting, GameUI ui)
	{
		Add(new StartDeckCardDrawingSystem(contexts, setting));
		Add(new StartTurnDrawSystem(contexts, setting));
		Add(new PlayerDeckCreatingSystem(contexts, ui.DeckFactory));
		Add(new PlayerDeckRenderingSystem(contexts));
		Add(new ShareDeckRenderingSystem(contexts, ui.DeckFactory.AllContainers[0]));
		Add(new LocalPlayerDeckRenderingSystem(contexts));
		Add(new LocalDeckCardStatusRenderingSystem(contexts, ui.LocalPlayerStatus));
		Add(new TargetDeckCardStatusRendingSystem(contexts, ui.TargetPlayerStatus));
	}

	private void CreateBoxCardSystems(Contexts contexts, GameUI ui)
	{
		Add(new PlayerBoxCreatingSystem(contexts, ui.BoxFactory));
		Add(new LocalPlayerBoxRenderingSystem(contexts));
		Add(new BoxCardRenderingSystem(contexts));
	}

	private void CreateSkillCardSystems(Contexts contexts, GameUI ui)
	{
		Add(new SkillCardContainerRenderingSystem(contexts, ui.SkillFactory));
		Add(new LocalSkillCardContainerRenderingSystem(contexts));
	}
}