using NUnit.Framework;
using End.Game;

namespace End.Test.System
{
	public class TestLoadCharacterIconSystem : ContextsTest
	{
		private CharacterSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().UnitSetting.CharacterSetting;
		}

		[Test]
		public void IconObjectCreated()
		{
			var system = new LoadCharacterIconSystem(_contexts, _setting);

			var context = _contexts.game;
			var entity = context.CreateEntity();
			entity.AddResource("Game/Unit/Character/LastBoss/[Character]Image_Lastboss", null);
			entity.AddCharacter(Character.LastBoss);

			system.Execute();

			Assert.IsTrue(entity.hasCharacterIcon);
			Assert.IsNotNull(entity.characterIcon.IconObject);
		}
	}
}

