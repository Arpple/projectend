using UnityEngine;
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

			Assert.IsTrue(p.hasPlayerSkillCardUI);
		}

		[Test]
		public void AddNewSkillToUI()
		{
			var p = TestHelper.CreatePlayerEntity(_contexts.game, 1);
			p.AddPlayerSkillCardUI(_container);

			var card = _contexts.game.CreateEntity();
			card.AddView(new GameObject());
			card.isSkillCard = true;
			card.AddPlayerCard(p);

			_system.Execute();

			Assert.AreEqual(p.playerSkillCardUI.ContainerObject.ObjectContainer, card.view.GameObject.transform.parent.gameObject);
		}
	}

}
