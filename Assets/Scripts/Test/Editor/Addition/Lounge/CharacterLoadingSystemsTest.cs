using System;
using NUnit.Framework;
using Lounge;

namespace Test.AdditionTest.LoungeTest
{
	public class CharacterLoadingSystemsTest : ContextsTest
	{
		[Test]
		public void Initialize_UsingGameSetting_CreateCharacterCountEqualEnum()
		{
			var system = new CharacterLoadingSystems(_contexts);
			system.Initialize();

			var enumCount = Enum.GetNames(typeof(Character)).Length;

			Assert.AreEqual(enumCount, _contexts.unit.count);
		}

		[Test]
		public void Initialize_UsingGameSetting_AllHaveCharacterComponent()
		{
			var system = new CharacterLoadingSystems(_contexts);
			system.Initialize();

			foreach (var e in _contexts.unit.GetEntities())
			{
				Assert.IsTrue(e.hasCharacter);
			}
		}
	}
}
