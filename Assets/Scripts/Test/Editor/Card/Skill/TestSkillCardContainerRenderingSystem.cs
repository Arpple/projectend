using NUnit.Framework;
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

			_system = new SkillCardContainerRenderingSystem(_contexts);
		}

		[Test]
		public void AddNewSkillToUI()
		{
			var p = CreatePlayerEntity(1);
			p.AddSkillCardContainer(_container);

			var card = _contexts.card.CreateEntity();
			card.AddView(new GameObject());
			card.AddSkillCard(SkillCard.Test);
			card.AddOwner(p);

			_system.Execute();

			Assert.AreEqual(p.skillCardContainer.ContainerObject.ObjectContainer, card.view.GameObject.transform.parent.gameObject);
		}
	}

}
