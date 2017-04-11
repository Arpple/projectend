﻿using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Game;
using Game.UI;

namespace Test.System
{
	public class TestShareDeckRenderingSystem : ContextsTest
	{
		private CardContainer _deck;

		[SetUp]
		public void Init()
		{
			var obj = new GameObject();
			_deck = obj.AddComponent<CardContainer>();
			_deck.Init();
		}

		[Test]
		public void CardMoveToDeckWhenPlayerCardComponentRemoved()
		{
			var system = new ShareDeckRenderingSystem(_contexts, _deck);
			var card = _contexts.card.CreateEntity();
			card.AddGameOwner(null);
			card.isGameDeckCard = true;
			card.RemoveGameOwner();
			card.AddGameView(new GameObject());

			system.Execute();

			Assert.AreEqual(_deck.ObjectContainer, card.gameView.GameObject.transform.parent.gameObject);
		}
	}

}
