using Entitas;

namespace End.Game.UI
{
	public class SceneSetupSystem : Feature
	{
		public SceneSetupSystem(Contexts contexts, GameUI gameUI) : base("Scene Setup System")
		{
			Add(new SetupEndButtonSystem(contexts, gameUI.ActionButtonGroup.EndButton));
			Add(new SetupBoxButtonSystem(contexts, gameUI.ActionButtonGroup.BoxButton));
			Add(new SetupCardButtonSystem(contexts, gameUI.ActionButtonGroup.CardButton));
			Add(new SetupSkillButtonSystem(contexts, gameUI.ActionButtonGroup.SkillButton));
			Add(new SetupTurnButtonSystem(contexts, gameUI.ActionButtonGroup.TurnButton));

			Add(new CreatePlayerDeckSystem(contexts, gameUI.InventoryGroup.CardContainer));
			Add(new CreatePlayerBoxSystem(contexts));
		}

	}
}

