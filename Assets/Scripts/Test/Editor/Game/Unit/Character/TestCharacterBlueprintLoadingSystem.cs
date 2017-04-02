using NUnit.Framework;
using End.Game;

namespace End.Test
{
	public class TestCharacterBlueprintLoadingSystem
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
		public void LoadCharacter()
		{
			var system = new CharacterBlueprintLoadingSystem(_contexts, _setting);

			var entity = _contexts.game.CreateEntity();
			entity.AddCharacter(Character.LastBoss);

			system.Initialize();

			Assert.IsTrue(entity.hasResource);
		}
	}
}

