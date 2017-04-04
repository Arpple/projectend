using NUnit.Framework;
using UnityEngine;
using Game;
using Entitas.Unity;

namespace Test.System
{
	public class TestLoadResourceSystem : ContextsTest
	{
		[Test]
		public void LoadResourcesWithSprite()
		{
			var system = new LoadResourceSystem(_contexts);
			var entity = _contexts.game.CreateEntity();

			entity.AddGameResource("Test/Editor/Sprite", null);
			system.Execute();

			//then 
			Assert.IsNotNull(entity.gameView.GameObject.GetComponent<SpriteRenderer>());
			Assert.IsTrue(entity.hasGameView);
			Assert.AreEqual(entity, entity.gameView.GameObject.GetEntityLink().entity);
		}

		[Test]
		public void LoadResourcesWithSpriteAndBasePrefabs()
		{
			var system = new Game.LoadResourceSystem(_contexts);
			var entity = _contexts.game.CreateEntity();
			entity.AddGameResource("Test/Editor/Sprite", "Test/Editor/Prefabs");

			system.Execute();

			Assert.AreEqual("Prefabs(Clone)", entity.gameView.GameObject.name);
			Assert.IsNotNull(entity.gameView.GameObject.GetComponent<SpriteRenderer>());
			Assert.IsTrue(entity.hasGameView);
			Assert.AreEqual(entity, entity.gameView.GameObject.GetEntityLink().entity);
		}

		[Test]
		public void LoadResourcesWithSpriteAndCustomViewBasePrefabs()
		{
			var system = new Game.LoadResourceSystem(_contexts);
			var entity = _contexts.game.CreateEntity();
			entity.AddGameResource("Test/Editor/Sprite", "Test/Editor/CustomViewPrefabs");

			system.Execute();

			Assert.AreEqual("CustomName", entity.gameView.GameObject.name);
		}
	}

	
}

