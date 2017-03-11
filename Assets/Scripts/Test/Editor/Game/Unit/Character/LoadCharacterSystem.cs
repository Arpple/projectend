using UnityEngine;
using NUnit.Framework;
using End.Game;

namespace End.Test
{
	public class LoadCharacterSystem
	{
		private Contexts _contexts;
		private Game.CharacterSetting _setting;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();

			GameSetting setting = Resources.Load<GameSetting>("Game/Core/_Setting/GameSetting");
			_setting = setting.UnitSetting.CharacterSetting;
			Assert.IsNotNull(_setting);
		}

		[Test]
		public void LoadCharacter()
		{
			var system = new Game.LoadCharacterSystem(_contexts, _setting);

			var entity = _contexts.game.CreateEntity();
			entity.AddCharacter(Character.LastBoss);

			system.Execute();

			Assert.IsTrue(entity.hasResource);
		}
	}
}

