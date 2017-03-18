using UnityEngine;
using System.Collections.Generic;
using Entitas;
using End.UI;

namespace End.Game.CharacterSelect
{
	public class CreateCharacterSelectionIconSystem : ReactiveSystem<GameEntity>
	{
		private readonly SlideMenu _slidemenu;

		public CreateCharacterSelectionIconSystem(Contexts contexts, SlideMenu slideMenu)
			: base(contexts.game)
		{
			_slidemenu = slideMenu;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Character, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasCharacter;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				var slideItem = _slidemenu.AddItem();
				var icon = Resources.Load<Sprite>(LoadCharacterIconSystem.GetIconPath(e.resource));
				slideItem.Content.GetComponent<Icon>().SetImage(icon);
				slideItem.SetText(e.unitStatus.Name);
			}
		}
	}
}

