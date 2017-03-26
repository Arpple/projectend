﻿using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using End.Game;
using End.Game.UI;

namespace End.Test
{
	public class TestRenderMiddleDeckSystem
	{
		private Contexts _contexts;
		private CardContainer _container;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			var obj = new GameObject();
			_container = obj.AddComponent<CardContainer>();
			_container.PlayerDeckPrefabs = new GameObject();
			_container.Awake();
		}

		[Test]
		public void CardViewObjectMovedToDeckObject()
		{
			var system = new RenderShareDeckSystem(_contexts, _container);
			var card = _contexts.game.CreateEntity();
			card.AddPlayerDeckCard(0);
			card.AddView(new GameObject());

			system.Execute();

			Assert.AreEqual(_container.PlayerDecks[0], card.view.GameObject.transform.parent.gameObject);
		}
	}

}

