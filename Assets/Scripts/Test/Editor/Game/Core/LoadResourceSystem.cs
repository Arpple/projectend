using NUnit.Framework;
using System;
using End.Game;
using End.Game.CharacterSelect;

namespace End.Test
{
	public class TestLoadResourceSystem
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
		public void EntityCreateCountMatchEnum()
		{
			var targetCount = Enum.GetNames(typeof(Character)).Length;

			var system = new LoadAllCharacterSystems(_contexts, _setting);
			system.Initialize();

			Assert.AreEqual(targetCount, _contexts.game.GetEntities().Length);
		}
	}

	
}

