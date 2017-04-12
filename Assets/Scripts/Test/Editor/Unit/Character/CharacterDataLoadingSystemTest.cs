﻿using NUnit.Framework;

namespace Test.UnitTest
{
	public class CharacterDataLoadingSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new CharacterDataLoadingSystem(_contexts, TestHelper.GetGameSetting().UnitSetting));
		}

		[Test]
		public void Execute_CharacterEntityAdded_ComponentFromDataLoaded()
		{
			var cha = _contexts.unit.CreateEntity();
			cha.AddCharacter(Character.LastBoss);

			_systems.Execute();
			Assert.IsTrue(cha.hasSprite);
		}
	}
}
