using UnityEngine;

public class UnitSystems : Feature
{
	Contexts _contexts;
	GameUI _ui;
	SystemController _syscon;

	public UnitSystems(Contexts contexts, UnitSetting setting, GameObject characterContainer, GameUI ui, SystemController syscon) : base("Unit System")
	{
		_contexts = contexts;
		_ui = ui;
		_syscon = syscon;

		Add(new PlayerCharacterCreatingSystem(contexts));
		Add(new CharacterDataLoadingSystem(contexts, setting.CharacterSetting));
		Add(new BossDataLoadingSystem(contexts, setting.BossSetting));
		Add(new SkillResourceLoadingSystem(contexts));
		Add(new UnitViewCreatingSystem(contexts, characterContainer));
		Add(new CharacterGameObjectRenameSystem(contexts));
		Add(new DeadSystem(contexts));
		Add(new UnitPositionRenderingSystem(contexts));
		Add(new LocalCharacterFlagSystem(contexts));
		Add(new LocalCharacterHpBarSystem(contexts, ui.LocalPlayerStatus.HpBar));
		Add(new LocalCharacterStatusSetupSystem(contexts, ui.LocalPlayerStatus));
		Add(new LocalCharacterStatusRenderingSystem(contexts, ui.LocalPlayerStatus));
		Add(new TargetUnitStatusDisplaySystem(contexts, ui.TargetPlayerStatus));
        Add(new RenderDeadSpriteSystem(contexts, setting));
        Add(new RenderResurrectionSpriteSystem(contexts));
		CreateBossSystems();
	}

	private void CreateBossSystems()
	{
		Add(new BossGameobjectRenameSystem(_contexts));
		Add(new BossActiveSkillUsingSystem(_contexts, _ui.TurnNoti, _syscon));
	}
}