using NUnit.Framework;
using UnityEngine;
using Game;
using Entitas.Unity;
using Entitas;

namespace Test.System
{
	public class TestLoadResourceSystem : ContextsTest
	{
		private Systems _systems;

		[SetUp]
		public void Init()
		{
			_systems = new Systems();
			_systems.Add(new LoadResourceSystem(_contexts));
		}

		[Test]
		public void LoadResourcesWithSprite()
		{
			var entity = _contexts.game.CreateEntity();

			entity.AddGameResource("Test/Editor/Sprite", null);
			_systems.Execute();

			//then 
			Assert.IsNotNull(entity.gameView.GameObject.GetComponent<SpriteRenderer>());
			Assert.IsTrue(entity.hasGameView);
			Assert.AreEqual(entity, entity.gameView.GameObject.GetEntityLink().entity);
		}

		[Test]
		public void LoadResourcesWithSpriteAndBasePrefabs()
		{
			var entity = _contexts.game.CreateEntity();
			entity.AddGameResource("Test/Editor/Sprite", "Test/Editor/Prefabs");

			_systems.Execute();

			Assert.AreEqual("Prefabs(Clone)", entity.gameView.GameObject.name);
			Assert.IsNotNull(entity.gameView.GameObject.GetComponent<SpriteRenderer>());
			Assert.IsTrue(entity.hasGameView);
			Assert.AreEqual(entity, entity.gameView.GameObject.GetEntityLink().entity);
		}

		[Test]
		public void LoadResourcesWithSpriteAndCustomViewBasePrefabs()
		{
			var entity = _contexts.game.CreateEntity();
			entity.AddGameResource("Test/Editor/Sprite", "Test/Editor/CustomViewPrefabs");

			_systems.Execute();

			Assert.AreEqual("CustomName", entity.gameView.GameObject.name);
		}

		[TearDown]
		public void Destroy()
		{
			_systems.ClearReactiveSystems();
			_systems.TearDown();
		}
	}

	
}

