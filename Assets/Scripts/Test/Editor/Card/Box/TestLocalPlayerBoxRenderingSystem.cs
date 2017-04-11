using NUnit.Framework;
using UnityEngine;

namespace Test.CardTest.BoxTest
{
	public class TestLocalPlayerBoxComponentRenderingSystem : ContextsTest
	{
		private PlayerBox _container;

		[SetUp]
		public void Init()
		{
			_systems.Add(new LocalPlayerBoxComponentRenderingSystem(_contexts));
			_container = new GameObject().AddComponent<PlayerBox>();
			_container.Init();
		}

		[Test]
		public void SetLocalPlayer()
		{
			var p = _contexts.game.CreateEntity();
			p.AddPlayerBox(_container);
			p.isLocal = true;

			_systems.Execute();

			Assert.IsTrue(p.playerBox.BoxObject.gameObject.activeSelf);
		}

		[Test]
		public void RemoveLocalPlayer()
		{
			_container.gameObject.SetActive(true);

			var p = _contexts.game.CreateEntity();
			p.AddPlayerBox(_container);
			p.isLocal = true;
			p.isLocal = false;

			_systems.Execute();

			Assert.IsFalse(p.playerBox.BoxObject.gameObject.activeSelf);
		}
	}
}
