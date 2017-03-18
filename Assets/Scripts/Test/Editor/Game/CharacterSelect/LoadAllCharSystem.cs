using Entitas;
using NUnit.Framework;
using System;

namespace End.Test
{
	public class LoadAllCharSytem
	{
		private Contexts _contexts;
		private Game.CharacterSetting _setting;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			_setting = TestHelper.GetGameSetting().UnitSetting.CharacterSetting;
		}

		[Test]
		public void LoadCharacterCountEqualEnum()
		{
			var system = new Game.CharacterSelect.LoadAllCharacterSystems(_contexts, _setting);
			system.Initialize();

			var enumCount = Enum.GetNames(typeof(Game.Character)).Length;

			Assert.AreEqual(enumCount, _contexts.game.count);
			
		}

		[Test]
		public void CharacterComponentAdded()
		{
			var system = new Game.CharacterSelect.LoadAllCharacterSystems(_contexts, _setting);
			system.Initialize();

			foreach (var e in _contexts.game.GetEntities())
			{
				Assert.IsTrue(e.hasCharacter);
			}
		}
	}
}
