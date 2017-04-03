using UnityEngine;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using End.UI;
using UnityEngine.Assertions;
using End.Game;

namespace End.CharacterSelect
{
	public class CreateCharacterSelectionIconSystem : ReactiveSystem<GameEntity>, ITearDownSystem
	{
		private readonly GameContext _context;
		private readonly SlideMenu _slidemenu;
		private List<GameObject> _linkedObjects;

		public CreateCharacterSelectionIconSystem(Contexts contexts, SlideMenu slideMenu)
			: base(contexts.game)
		{
			_context = contexts.game;
			_slidemenu = slideMenu;
			_linkedObjects = new List<GameObject>();
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Character, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasCharacter && entity.character.Type != Character.None;
		}

		protected override void Execute(List<GameEntity> entities)
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

            this._slidemenu.FocusIndex(0); //because 0 is ... umm ... None (Deactive) Object
            //Debug.Log("Init Focus on > "+_slidemenu.FocusingIndex);
        }

		public void TearDown()
		{
			_linkedObjects.ForEach(e => e.Unlink());
		}
	}
}

