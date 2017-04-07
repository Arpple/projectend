﻿using UnityEngine;
using Game.UI;
using NUnit.Framework;

namespace Test.System
{
	public class TestLocalPlayerDeckRenderingSystem : ContextsTest
	{
		private CardContainer _container;

		[SetUp]
		public void Init()
		{
			_systems.Add(new LocalPlayerDeckRenderingSystem(_contexts));
			_container = new GameObject().AddComponent<CardContainer>();
			_container.Init();
		}

		[Test]
		public void SetLocalPlayer()
		{
			var p = _contexts.game.CreateEntity();
			p.AddGamePlayerDeck(_container);
			p.isGameLocal = true;

			_systems.Execute();

			Assert.IsTrue(p.gamePlayerDeck.PlayerDeckObject.gameObject.activeSelf);
		}

		[Test]
		public void RemoveLocalPlayer()
		{
			_container.gameObject.SetActive(true);

			var p = _contexts.game.CreateEntity();
			p.AddGamePlayerDeck(_container);
			p.isGameLocal = true;
			p.isGameLocal = false;

			_systems.Execute();

			Assert.IsFalse(p.gamePlayerDeck.PlayerDeckObject.gameObject.activeSelf);
		}
	}
}
