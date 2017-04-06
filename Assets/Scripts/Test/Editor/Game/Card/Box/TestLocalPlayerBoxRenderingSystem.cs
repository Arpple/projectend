using UnityEngine;
using Game.UI;
using NUnit.Framework;

namespace Test.System
{
	public class TestLocalPlayerBoxRenderingSystem : ContextsTest
	{
		private PlayerBox _container;

		[SetUp]
		public void Init()
		{
			_systems.Add(new LocalPlayerBoxRenderingSystem(_contexts));
			_container = new GameObject().AddComponent<PlayerBox>();
			_container.Init();
		}

		[Test]
		public void SetLocalPlayer()
		{
			var p = _contexts.game.CreateEntity();
			p.AddGamePlayerBox(_container);
			p.isGameLocal = true;

			_systems.Execute();

			Assert.IsTrue(p.gamePlayerBox.BoxObject.gameObject.activeSelf);
		}

		[Test]
		public void RemoveLocalPlayer()
		{
			_container.gameObject.SetActive(true);

			var p = _contexts.game.CreateEntity();
			p.AddGamePlayerBox(_container);
			p.isGameLocal = true;
			p.isGameLocal = false;

			_systems.Execute();

			Assert.IsFalse(p.gamePlayerBox.BoxObject.gameObject.activeSelf);
		}
	}
}
