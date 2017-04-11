using NUnit.Framework;
using UnityEngine;


namespace Test.UnitTest
{
	public class TestCharacterIconLoadingSystem : ContextsTest
	{
		[Test]
		public void IconSpriteLoaded()
		{
			var system = new CharacterIconLoadingSystem(_contexts);

			var spritePath = "Test/Editor/Sprite";
			var sprite = Resources.Load<Sprite>(spritePath);

			var character = _contexts.unit.CreateEntity();
			character.AddCharacter(Character.LastBoss);
			character.AddUnitIconResource(spritePath);

			system.Initialize();

			Assert.IsTrue(character.hasUnitIcon);
			Assert.AreEqual(sprite, character.unitIcon.IconSprite);
		}
	}
}
