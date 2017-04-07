using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Game.UI;

namespace Test.System
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
			var p = TestHelper.CreatePlayerEntity(_contexts.game, 1);

			_system.Initialize();

			Assert.IsTrue(p.hasGameSkillCardContainer);
		}

		[Test]
		public void AddNewSkillToUI()
		{
			var p = TestHelper.CreatePlayerEntity(_contexts.game, 1);
			p.AddGameSkillCardContainer(_container);

			var card = _contexts.card.CreateEntity();
			card.AddGameView(new GameObject());
			card.isGameSkillCard = true;
			card.AddGameOwner(p);

			_system.Execute();

			Assert.AreEqual(p.gameSkillCardContainer.ContainerObject.ObjectContainer, card.gameView.GameObject.transform.parent.gameObject);
		}
	}

}
