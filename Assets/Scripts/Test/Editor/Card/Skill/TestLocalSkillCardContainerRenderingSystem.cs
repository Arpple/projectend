using UnityEngine;

using NUnit.Framework;

namespace Test.CardTest.SkillTest
{
	public class TestLocalSkillCardContainerRenderingSystem : ContextsTest
	{
		private CardContainer _container;

		[SetUp]
		public void Init()
		{
			_systems.Add(new LocalSkillCardContainerRenderingSystem(_contexts));
			_container = new GameObject().AddComponent<CardContainer>();
			_container.Init();
		}

		[Test]
		public void SetLocalPlayer()
		{
			var p = _contexts.game.CreateEntity();
			p.AddSkillCardContainer(_container);
			p.isLocal = true;

			_systems.Execute();

			Assert.IsTrue(p.skillCardContainer.ContainerObject.gameObject.activeSelf);
		}

		[Test]
		public void RemoveLocalPlayer()
		{
			_container.gameObject.SetActive(true);

			var p = _contexts.game.CreateEntity();
			p.AddSkillCardContainer(_container);
			p.isLocal = true;
			p.isLocal = false;

			_systems.Execute();

			Assert.IsFalse(p.skillCardContainer.ContainerObject.gameObject.activeSelf);
		}
	}
}
