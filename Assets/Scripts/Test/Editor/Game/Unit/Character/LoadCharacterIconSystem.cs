using NUnit.Framework;
using End.Game;

namespace End.Test
{
	public class TestLoadCharacterIconSystem
	{
		private Contexts _contexts;
		private CharacterSetting _setting;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			_setting = TestHelper.GetGameSetting().UnitSetting.CharacterSetting;
		}

		[Test]
		public void IconObjectCreated()
		{
			var system = new LoadCharacterIconSystem(_contexts, _setting);

			var context = _contexts.game;
			var entity = context.CreateEntity();
			entity.AddResource("Game/Unit/Character/LastBoss/[Character]Image_Lastboss", null);
			entity.AddCharacter(End.Game.Character.LastBoss);

			system.Execute();

			Assert.IsTrue(entity.hasCharacterIcon);
			Assert.IsNotNull(entity.characterIcon.IconObject);
		}
	}
}

