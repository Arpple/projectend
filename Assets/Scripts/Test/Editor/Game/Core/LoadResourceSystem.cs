﻿using System;
using Entitas;
using Entitas.Unity;
using NUnit.Framework;
using UnityEngine;

namespace End.Test
{
	public class LoadResourceSystem
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
			//given
			var system = new End.LoadResourceSystem(_contexts);

			var entity = _contexts.game.CreateEntity();
			entity.AddResource("Test/Editor/Sprite", null);

			//action
			system.Execute();

			//then
			Assert.IsNotNull(entity.view.GameObject.GetComponent<SpriteRenderer>());
			Assert.IsTrue(entity.hasView);
			Assert.AreEqual(entity, entity.view.GameObject.GetEntityLink().entity);
		}

		[Test]
		public void LoadResourcesWithSpriteAndBasePrefabs()
		{
			var system = new End.LoadResourceSystem(_contexts);
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
			var system = new End.LoadResourceSystem(_contexts);
			var entity = _contexts.game.CreateEntity();
			entity.AddResource("Test/Editor/Sprite", "Test/Editor/CustomViewPrefabs");

			system.Execute();

			Assert.AreEqual("CustomName", entity.view.GameObject.name);
		}
	}

	
}

