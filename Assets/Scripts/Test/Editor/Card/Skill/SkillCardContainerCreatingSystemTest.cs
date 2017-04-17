using NUnit.Framework;
using UnityEngine;

namespace Test.CardTest.SkillTest
{
	public class SkillCardContainerCreatingSystemTest : ContextsTest
	{
		CardContainer _container;

		[SetUp]
		public void Init()
		{
			_container = new GameObject().AddComponent<CardContainer>();
			_container.Init();

			var factory = new GameObject().AddComponent<PlayerSkillFactory>();
			factory.Init();
			factory.ContainerPrefabs = _container;

			_systems.Add(new SkillCardContainerCreatingSystem(_contexts, factory));
		}

		[Test]
		public void Excecute_PlayerAdded_SkillCardContainerCreated()
		{
			var p = CreatePlayerEntity(1);

			_systems.Execute();

			Assert.IsTrue(p.hasSkillCardContainer);
		}
	}
}
