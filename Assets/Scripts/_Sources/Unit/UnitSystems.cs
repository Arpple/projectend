using UnityEngine;

public class UnitSystems : Feature
{
	public UnitSystems(Contexts contexts, UnitSetting setting, GameObject characterContainer, GameUI ui) : base("Unit System")
	{
		Add(new PlayerCharacterCreatingSystem(contexts));
		Add(new CharacterDataLoadingSystem(contexts, setting));
		Add(new CharacterViewCreatingSystem(contexts, characterContainer));
		Add(new DeadSystem(contexts));
		Add(new UnitPositionRenderingSystem(contexts));
		Add(new LocalCharacterFlagSystem(contexts));
		Add(new LocalCharacterHpBarSystem(contexts, ui.LocalPlayerStatus.HpBar));
		Add(new LocalCharacterStatusSetupSystem(contexts, ui.LocalPlayerStatus));
		Add(new LocalCharacterStatusRenderingSystem(contexts, ui.LocalPlayerStatus));
		Add(new TargetUnitStatusDisplaySystem(contexts, ui.TargetPlayerStatus));
	}
}