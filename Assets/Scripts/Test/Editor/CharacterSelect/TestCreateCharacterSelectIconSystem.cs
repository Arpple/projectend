using NUnit.Framework;
using CharacterSelect;
using Game;
using UI;
using UnityEngine;

namespace Test.System
{
	public class TestCreateCharacterSelectIconSystem : ContextsTest
	{
		private SlideMenu _slideMenu;
		
		[SetUp]
		public void Init()
		{
			_slideMenu = SlideMenu.Instantiate(Resources.Load<SlideMenu>("Misc/SlideMenu/SlideMenu"));
		}

		[Test]
		public void CreateSlideItemAndAddToSlideMenu()
		{
			var system = new CreateCharacterSelectionIconSystem(_contexts, _slideMenu);
			var entity = _contexts.unit.CreateEntity();
			entity.AddGameResource("Game/Unit/Character/LastBoss/[Character]Image_Lastboss", null);
			entity.AddGameUnitStatus(0, 0, 0, 0, 0);
			entity.AddGameUnitDetail("", "");
			entity.AddGameCharacter(Character.LastBoss);
			entity.AddGameUnitIcon(null);

			system.Execute();

			Assert.AreEqual(1, _slideMenu.ItemCount);

			system.TearDown();
		}
	}

}
