﻿using NUnit.Framework;
using UnityEngine;


namespace Test.CardTest.SkillTest
{
	public class TestSkillCardContainerRenderingSystem : ContextsTest
	{
		SkillCardContainerRenderingSystem _system;
		CardContainer _container;

		[SetUp]
		public void Init()
		{
			_container = new GameObject().AddComponent<CardContainer>();
			_container.Init();

			var factory = new GameObject().AddComponent<PlayerSkillFactory>();
			factory.Init();
			factory.ContainerPrefabs = _container;

			_system = new SkillCardContainerRenderingSystem(_contexts, factory);
		}

		[Test]
		public void Initialize()
		{
			var p = CreatePlayerEntity(1);

			_system.Initialize();

			Assert.IsTrue(p.hasSkillCardContainer);
		}

		[Test]
		public void AddNewSkillToUI()
		{
			var p = CreatePlayerEntity(1);
			p.AddSkillCardContainer(_container);

			var card = _contexts.card.CreateEntity();
			card.AddView(new GameObject());
			card.isSkillCard = true;
			card.AddOwner(p);

			_system.Execute();

			Assert.AreEqual(p.skillCardContainer.ContainerObject.ObjectContainer, card.view.GameObject.transform.parent.gameObject);
		}
	}

}