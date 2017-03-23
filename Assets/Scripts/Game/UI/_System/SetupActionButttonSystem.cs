using System;
using Entitas;
using End.Game.UI;

namespace End.Game.UI
{
	public class SetupActionButtonSystem : Feature
	{
		public SetupActionButtonSystem(Contexts contexts) : base("ActionButton Systems")
		{
			Add(new SetupEndButtonSystem(contexts, GameUI.Instance.ActionButtonGroup.EndButton));
			Add(new SetupBoxButtonSystem(contexts, GameUI.Instance.ActionButtonGroup.BoxButton));
			Add(new SetupCardButtonSystem(contexts, GameUI.Instance.ActionButtonGroup.CardButton));
			Add(new SetupSkillButtonSystem(contexts, GameUI.Instance.ActionButtonGroup.SkillButton));
			Add(new SetupTurnButtonSystem(contexts, GameUI.Instance.ActionButtonGroup.TurnButton));
		}
	}

	public abstract class ActionButtonSystem : IInitializeSystem
	{
		protected readonly ActionButton _button;
		protected readonly Contexts _contexts;

		public ActionButtonSystem(Contexts contexts, ActionButton button)
		{
			_button = button;
			_contexts = contexts;
		}

		public abstract void Initialize();
	}
}

