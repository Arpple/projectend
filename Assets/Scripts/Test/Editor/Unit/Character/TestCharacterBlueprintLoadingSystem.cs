using NUnit.Framework;


namespace Test.UnitTest
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

			var entity = _contexts.unit.CreateEntity();
			entity.AddCharacter(Character.LastBoss);

			system.Initialize();

			Assert.IsTrue(entity.hasResource);
		}
	}
}

