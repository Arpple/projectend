using UnityEngine;
using Entitas;

namespace Game.UI
{
	public class GameUIRenderingSystems : Feature
	{
		public GameUIRenderingSystems(Contexts contexts, GameUI ui) : base("UI")
		{
			Add(new NewDeckCardToShareDeckSystem(contexts, ui.DeckFactory.AllContainers[0]));
			Add(new RenderShareDeckSystem(contexts, ui.DeckFactory.AllContainers[0]));

			Add(new LocalPlayerDeckSystem(contexts));
			Add(new LocalPlayerBoxSystem(contexts));
			Add(new LocalPlayerSkillCardContainerSystem(contexts));
			Add(new LocalPlayerDeckCardStatusSystem(contexts, ui.LocalPlayerStatus));
			Add(new TargetPlayerDeckCardStatusSystem(contexts, ui.TargetPlayerStatus));

			Add(new ViewContainerSystem(contexts));
		}
	}

}
