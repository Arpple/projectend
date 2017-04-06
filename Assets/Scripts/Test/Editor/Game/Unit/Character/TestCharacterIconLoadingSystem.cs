using NUnit.Framework;
using UnityEngine;
using Game;

namespace Test.System
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
			character.AddGameCharacter(Character.LastBoss);
			character.AddGameUnitIconResource(spritePath);

			system.Initialize();

			Assert.IsTrue(character.hasGameUnitIcon);
			Assert.AreEqual(sprite, character.gameUnitIcon.IconSprite);
		}
	}
}
