public class CardSystems : Feature
{
	public CardSystems(Contexts contexts, CardSetting setting, GameUI ui, bool isServer) : base("Card System")
	{
		Add(new DeckCardCreatingSystem(contexts, setting.DeckSetting));
		Add(new DeckCardDataLoadingSystem(contexts, setting.DeckSetting));
		Add(new ResourceCardDataLoadingSystem(contexts, setting.ResourceCardSetting));
		Add(new SkillCardDataLoadingSystem(contexts, setting.SkillCardSetting));
		Add(new CardViewCreatingSystem(contexts, setting));
		Add(new CardChargeRenderingSystem(contexts));

		CreateDeckCardSystems(contexts, setting.DeckSetting, ui, isServer);
		CreateBoxCardSystems(contexts, ui);
		CreateSkillCardSystems(contexts, ui);
		CreateResourceCardSystems(contexts, setting.ResourceCardSetting);
        CreateAbilitySystem(contexts);

		Add(new ResourceCardDestroySystem(contexts));

        

    }
    
	private void CreateDeckCardSystems(Contexts contexts, DeckSetting setting, GameUI ui, bool isServer)
	{
		if(isServer) Add(new StartDeckCardDrawingSystem(contexts, setting));
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
		Add(new SkillCardContainerCreatingSystem(contexts, ui.SkillFactory));
		Add(new SkillCardContainerRenderingSystem(contexts));
		Add(new LocalSkillCardContainerRenderingSystem(contexts));
	}

    private void CreateAbilitySystem(Contexts contexts) {
        Add(new BlockAggressiveEventSystem(contexts));
        Add(new BlockAttackSystem(contexts));
        Add(new DealDamageSystem(contexts));
    }

    private void CreateResourceCardSystems(Contexts contexts, ResourceCardSetting setting)
	{
		Add(new ResourceCardChargeRandomSystem(contexts, setting));
	}
}