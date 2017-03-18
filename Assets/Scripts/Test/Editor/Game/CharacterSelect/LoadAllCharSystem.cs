using NUnit.Framework;
using System;
using End.Game;

namespace End.Test
{
	public class TestLoadAllCharacterSystem
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
		public void LoadCharacterCountEqualEnum()
		{
			var system = new End.Game.CharacterSelect.LoadAllCharacterSystems(_contexts, _setting);
			system.Initialize();

			var enumCount = Enum.GetNames(typeof(Character)).Length;

			Assert.AreEqual(enumCount, _contexts.game.count);
			
		}

		[Test]
		public void CharacterComponentAdded()
		{
			var system = new End.Game.CharacterSelect.LoadAllCharacterSystems(_contexts, _setting);
			system.Initialize();

			foreach (var e in _contexts.game.GetEntities())
			{
				Assert.IsTrue(e.hasCharacter);
			}
		}
	}
}
