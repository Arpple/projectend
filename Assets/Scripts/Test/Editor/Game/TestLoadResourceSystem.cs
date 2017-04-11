using Entitas.Unity;
using NUnit.Framework;
using UnityEngine;

namespace Test.GameTest
{
	public class TestLoadResourceSystem : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new GameResouceLoadingSystem(_contexts));
		}

		[Test]
		public void LoadResourcesWithSprite()
		{
			var entity = _contexts.game.CreateEntity();

			entity.AddResource("Test/Editor/Sprite", null);
			_systems.Execute();

			//then 
			Assert.IsNotNull(entity.view.GameObject.GetComponent<SpriteRenderer>());
			Assert.IsTrue(entity.hasView);
			Assert.AreEqual(entity, entity.view.GameObject.GetEntityLink().entity);
		}

		[Test]
		public void LoadResourcesWithSpriteAndBasePrefabs()
		{
			var entity = _contexts.game.CreateEntity();
			entity.AddResource("Test/Editor/Sprite", "Test/Editor/Prefabs");

			_systems.Execute();

			Assert.AreEqual("Prefabs(Clone)", entity.view.GameObject.name);
			Assert.IsNotNull(entity.view.GameObject.GetComponent<SpriteRenderer>());
			Assert.IsTrue(entity.hasView);
			Assert.AreEqual(entity, entity.view.GameObject.GetEntityLink().entity);
		}

		[Test]
		public void LoadResourcesWithSpriteAndCustomViewBasePrefabs()
		{
			var entity = _contexts.game.CreateEntity();
			entity.AddResource("Test/Editor/Sprite", "Test/Editor/CustomViewPrefabs");

			_systems.Execute();

			Assert.AreEqual("CustomName", entity.view.GameObject.name);
		}

		[TearDown]
		public void Destroy()
		{
			_systems.TearDown();
		}
	}

	
}

