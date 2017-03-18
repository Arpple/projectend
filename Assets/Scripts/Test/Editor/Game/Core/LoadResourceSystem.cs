using NUnit.Framework;
using UnityEngine;
using End.Game;
using Entitas.Unity;

namespace End.Test
{
	public class TestLoadResourceSystem
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

		[Test]
		public void LoadResourcesWithSprite()
		{
			var system = new LoadResourceSystem(_contexts);
			var entity = _contexts.game.CreateEntity();

			entity.AddResource("Test/Editor/Sprite", null);
			system.Execute();

			//then 
			Assert.IsNotNull(entity.view.GameObject.GetComponent<SpriteRenderer>());
			Assert.IsTrue(entity.hasView);
			Assert.AreEqual(entity, entity.view.GameObject.GetEntityLink().entity);
		}

		[Test]
		public void LoadResourcesWithSpriteAndBasePrefabs()
		{
			var system = new Game.LoadResourceSystem(_contexts);
			var entity = _contexts.game.CreateEntity();
			entity.AddResource("Test/Editor/Sprite", "Test/Editor/Prefabs");

			system.Execute();

			Assert.AreEqual("Prefabs(Clone)", entity.view.GameObject.name);
			Assert.IsNotNull(entity.view.GameObject.GetComponent<SpriteRenderer>());
			Assert.IsTrue(entity.hasView);
			Assert.AreEqual(entity, entity.view.GameObject.GetEntityLink().entity);
		}

		[Test]
		public void LoadResourcesWithSpriteAndCustomViewBasePrefabs()
		{
			var system = new Game.LoadResourceSystem(_contexts);
			var entity = _contexts.game.CreateEntity();
			entity.AddResource("Test/Editor/Sprite", "Test/Editor/CustomViewPrefabs");

			system.Execute();

			Assert.AreEqual("CustomName", entity.view.GameObject.name);
		}
	}

	
}

