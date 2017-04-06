﻿using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Game.UI;

namespace Test.System
{
	public class TestPlayerSkillCardUISystem : ContextsTest
	{
		PlayerSkillCardUISystem _system;
		CardContainer _container;

		[SetUp]
		public void Init()
		{
			_container = new GameObject().AddComponent<CardContainer>();
			_container.Init();

			var factory = new GameObject().AddComponent<PlayerSkillFactory>();
			factory.Init();
			factory.ContainerPrefabs = _container;

			_system = new PlayerSkillCardUISystem(_contexts, factory);
		}

		[Test]
		public void Initialize()
		{
			var p = TestHelper.CreatePlayerEntity(_contexts.game, 1);

			_system.Initialize();

			Assert.IsTrue(p.hasGameUIPlayerSkillCardUI);
		}

		[Test]
		public void AddNewSkillToUI()
		{
			var p = TestHelper.CreatePlayerEntity(_contexts.game, 1);
			p.AddGameUIPlayerSkillCardUI(_container);

			var card = _contexts.game.CreateEntity();
			card.AddGameView(new GameObject());
			card.isGameSkillCard = true;
			card.AddGameOwner(p);

			_system.Execute();

			Assert.AreEqual(p.gameUIPlayerSkillCardUI.ContainerObject.ObjectContainer, card.gameView.GameObject.transform.parent.gameObject);
		}
	}

}
