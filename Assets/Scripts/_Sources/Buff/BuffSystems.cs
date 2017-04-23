public class BuffSystems : Feature
{
	public BuffSystems(Contexts contexts, Setting setting, GameUI ui) : base("Buff")
	{
		Add(new BuffDataLoadingSystem(contexts, setting.BuffSetting));
		
		Add(new BuffExhaustApplySystem(contexts, setting.BuffSetting));
		Add(new BuffExhaustExpireSystem(contexts, setting.BuffSetting));

		Add(new LocalBuffPanelAddingSystem(contexts, ui.LocalPlayerStatus.BuffPanel));
		Add(new LocalBuffPanelRemoveSystem(contexts, ui.LocalPlayerStatus.BuffPanel));

		Add(new BuffExpireSystem(contexts));
	}
}