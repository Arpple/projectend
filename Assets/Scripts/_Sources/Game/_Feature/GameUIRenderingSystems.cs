public class GameUIRenderingSystems : Feature
{
	public GameUIRenderingSystems(Contexts contexts, GameUI ui) : base("UI")
	{
		Add(new ShareDeckRenderingSystem(contexts, ui.DeckFactory.AllContainers[0]));

		Add(new LocalPlayerDeckRenderingSystem(contexts));
		Add(new LocalPlayerBoxComponentRenderingSystem(contexts));
		Add(new LocalSkillCardContainerRenderingSystem(contexts));
		Add(new LocalDeckCardStatusRenderingSystem(contexts, ui.LocalPlayerStatus));
		Add(new TargetDeckCardStatusRendingSystem(contexts, ui.TargetPlayerStatus));

		Add(new ViewContainerSystem(contexts));

		Add(new TurnNotificationSystem(contexts, ui.TurnNoti));
	}
}