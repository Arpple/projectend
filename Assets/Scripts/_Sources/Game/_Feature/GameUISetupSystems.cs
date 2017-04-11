public class GameUISetupSystems : Feature
{
	public GameUISetupSystems(Contexts contexts, GameUI ui) : base("Game UI Setup")
	{
		Add(new TurnPanelSetupSystem(contexts, ui.TurnPanel));
		Add(new LocalCharacterStatusSystem(contexts, ui.LocalPlayerStatus));
		Add(new LocalCharacterHpBarSystem(contexts, ui.LocalPlayerStatus.HpBar));
		Add(new TargetUnitStatusDisplaySystem(contexts, ui.TargetPlayerStatus));
		Add(new SkillCardContainerRenderingSystem(contexts, ui.SkillFactory));
	}
}