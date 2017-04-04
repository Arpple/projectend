using UnityEngine;
using System.Collections;
using Entitas;

namespace End.Game.UI
{
	public class GameUISetupSystem : Feature
	{
		public GameUISetupSystem(Contexts contexts, GameUI ui) : base("Game UI Setup")
		{
			Add(new TurnPanelSetupSystem(contexts, ui.TurnPanel));
			Add(new LocalCharacterStatusSystem(contexts, ui.LocalPlayerStatus));
			Add(new LocalCharacterHpBarSystem(contexts, ui.LocalPlayerStatus.HpBar));
			Add(new TargetUnitStatusDisplaySystem(contexts, ui.TargetPlayerStatus));
			Add(new PlayerSkillCardUISystem(contexts, ui.SkillFactory));
		}
	}
}
