using NUnit.Framework;
using Entitas;
using End.Game.CharacterSelect;
using End.Game;
using End.UI;
using UnityEngine;

namespace End.Test
{
	public class TestCreateCharacterSelectIconSystem
	{
		private Contexts _contexts;
		private SlideMenu _slideMenu;
		
		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			_slideMenu = SlideMenu.Instantiate(Resources.Load<SlideMenu>("Game/UI/Misc/SlideMenu/SlideMenu"));
		}

		[Test]
		public void CreateSlideItemAndAddToSlideMenu()
		{
			var system = new CreateCharacterSelectionIconSystem(_contexts, _slideMenu);
			var entity = _contexts.game.CreateEntity();
			entity.AddResource("Game/Unit/Character/LastBoss/[Character]Image_Lastboss", null);
			entity.AddUnitStatus("name", 0, 0, 0, 0, 0);
			entity.AddCharacter(Character.LastBoss);

			system.Execute();

			Assert.AreEqual(1, _slideMenu.ItemCount);
		}
	}

}
