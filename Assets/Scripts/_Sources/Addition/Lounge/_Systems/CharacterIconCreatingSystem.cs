using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using UI;

using UnityEngine;

namespace Lounge
{
	public class CharacterIconCreatingSystem : ReactiveSystem<UnitEntity>, ITearDownSystem
	{
		private readonly GameContext _context;
		private readonly SlideMenu _slidemenu;
		private List<GameObject> _linkedObjects;

		public CharacterIconCreatingSystem(Contexts contexts, SlideMenu slideMenu)
			: base(contexts.unit)
		{
			_context = contexts.game;
			_slidemenu = slideMenu;
			_linkedObjects = new List<GameObject>();
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
			foreach(var e in entities)
			{
				var slideItem = _slidemenu.AddItem();
				var icon = e.unitIcon.IconSprite;
				slideItem.Content.GetComponent<Icon>().SetImage(icon);
				slideItem.SetText(e.unitDetail.Name);
				slideItem.gameObject.Link(e, _context);
				_linkedObjects.Add(slideItem.gameObject);
            }

            this._slidemenu.FocusIndex(1); //because 0 is ... umm ... None (Deactive) Object
            //Debug.Log("Init Focus on > "+_slidemenu.FocusingIndex);
        }

		public void TearDown()
		{
			_linkedObjects.ForEach(e => e.Unlink());
		}
	}
}

