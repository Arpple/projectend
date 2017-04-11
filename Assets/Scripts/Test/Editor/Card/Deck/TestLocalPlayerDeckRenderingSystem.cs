using NUnit.Framework;
using UnityEngine;

namespace Test.CardTest.DeckTest
{
	public class TestLocalPlayerDeckRenderingSystem : ContextsTest
	{
		private CardContainer _container;

		[SetUp]
		public void Init()
		{
			_systems.Add(new LocalPlayerDeckRenderingSystem(_contexts));
			_container = new GameObject().AddComponent<CardContainer>();
			_container.Init();
		}

		[Test]
		public void SetLocalPlayer()
		{
			var p = _contexts.game.CreateEntity();
			p.AddPlayerDeck(_container);
			p.isLocal = true;

			_systems.Execute();

			Assert.IsTrue(p.playerDeck.PlayerDeckObject.gameObject.activeSelf);
		}

		[Test]
		public void RemoveLocalPlayer()
		{
			_container.gameObject.SetActive(true);

			var p = _contexts.game.CreateEntity();
			p.AddPlayerDeck(_container);
			p.isLocal = true;
			p.isLocal = false;

			_systems.Execute();

			Assert.IsFalse(p.playerDeck.PlayerDeckObject.gameObject.activeSelf);
		}
	}
}
