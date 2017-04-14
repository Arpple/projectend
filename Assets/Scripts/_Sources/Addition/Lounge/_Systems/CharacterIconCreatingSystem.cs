using System.Collections.Generic;
using Entitas;
using UI;
using UnityEngine;

namespace Lounge
{
	public class CharacterIconCreatingSystem : EntityViewCreatingSystem<UnitEntity>
	{
		private readonly SlideMenu _characterSelectionList;

		public CharacterIconCreatingSystem(Contexts contexts, SlideMenu characterSelectionList)
			: base(contexts.unit)
		{
			_characterSelectionList = characterSelectionList;
		}

		protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
		{
			return context.CreateCollector(UnitMatcher.Character, GroupEvent.Added);
		}

		protected override bool Filter(UnitEntity entity)
		{
			return entity.hasCharacter && entity.character.Type != Character.None;
		}

		protected override void Execute(List<UnitEntity> entities)
		{
			base.Execute(entities);
            _characterSelectionList.FocusIndex(1); //because 0 is ... umm ... None (Deactive) Object 
												   //? but none is filtered out :\
		}

		protected override GameObject CreateViewObject(UnitEntity entity)
		{
			var charSelectIcon = _characterSelectionList.AddItem();
			var charIcon = entity.unitIcon.IconSprite;
			charSelectIcon.Content.GetComponent<Icon>().SetImage(charIcon);
			charSelectIcon.SetText(entity.unitDetail.Name);
			return charSelectIcon.gameObject;
		}

		protected override void AddViewObject(UnitEntity entity, GameObject viewObject)
		{
			entity.AddView(viewObject);
		}
	}
}

