using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace End.Test
{
	public class LoadCharacterSystem
	{
		private Contexts _contexts;
		private End.CharacterSetting _setting;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();

			GameSetting setting = Resources.Load<GameSetting>("Game/Core/Setting/GameSetting");
			_setting = setting.UnitSetting.CharacterSetting;
			Assert.IsNotNull(_setting);
		}

		[Test]
		public void EditorTest()
		{
			var system = new End.LoadCharacterSystem(_contexts, _setting);

			var entity = _contexts.game.CreateEntity();
			entity.AddCharacter(Character.LastBoss);

			system.Execute();

			Assert.IsTrue(entity.hasResource);
		}
	}
}

