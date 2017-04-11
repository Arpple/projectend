using Lounge;
using NUnit.Framework;
using UI;
using UnityEngine;

namespace Test.AdditionTest.LoungeTest
{
	public class CharacterIconCreatingSystemTest : ContextsTest
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
			var system = new CharacterIconCreatingSystem(_contexts, _slideMenu);
			var entity = _contexts.unit.CreateEntity();
			entity.AddResource("Game/Unit/Character/LastBoss/[Character]Image_Lastboss", null);
			entity.AddUnitStatus(0, 0, 0, 0, 0);
			entity.AddUnitDetail("", "");
			entity.AddCharacter(Character.LastBoss);
			entity.AddUnitIcon(null);

			system.Execute();

			Assert.AreEqual(1, _slideMenu.ItemCount);

			system.TearDown();
		}
	}

}
