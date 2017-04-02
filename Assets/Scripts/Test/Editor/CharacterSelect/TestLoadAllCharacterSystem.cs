using NUnit.Framework;
using System;
using End.Game;

namespace End.Test.System
{
	public class TestLoadAllCharacterSystem : ContextsTest
	{
		private CharacterSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().UnitSetting.CharacterSetting;
		}

		[Test]
		public void LoadCharacterCountEqualEnum()
		{
			var system = new CharacterSelect.LoadAllCharacterSystems(_contexts, _setting);
			system.Initialize();

			var enumCount = Enum.GetNames(typeof(Character)).Length;

			Assert.AreEqual(enumCount, _contexts.game.count);
		}

		[Test]
		public void CharacterComponentAdded()
		{
			var system = new CharacterSelect.LoadAllCharacterSystems(_contexts, _setting);
			system.Initialize();

			foreach (var e in _contexts.game.GetEntities())
			{
				Assert.IsTrue(e.hasCharacter);
			}
		}
	}
}
