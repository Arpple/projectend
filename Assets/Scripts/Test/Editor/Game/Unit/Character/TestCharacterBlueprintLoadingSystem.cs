using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestCharacterBlueprintLoadingSystem : ContextsTest
	{
		private CharacterSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().UnitSetting.CharacterSetting;
		}

		[Test]
		public void LoadCharacter()
		{
			var system = new CharacterBlueprintLoadingSystem(_contexts, _setting);

			var entity = _contexts.game.CreateEntity();
			entity.AddGameCharacter(Character.LastBoss);

			system.Initialize();

			Assert.IsTrue(entity.hasGameResource);
		}
	}
}

