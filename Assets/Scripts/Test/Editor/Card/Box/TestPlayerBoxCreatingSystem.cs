using System.Linq;
using Entitas;
using Network;
using NUnit.Framework;
using UnityEngine;

namespace Test.CardTest.BoxTest
{
	public class TestPlayerBoxComponentCreatingSystem : ContextsTest
	{
		private PlayerBoxFactory _factory;

		[SetUp]
		public void Init()
		{
			var obj = new GameObject();
			_factory = obj.AddComponent<PlayerBoxFactory>();
			_factory.ContainerPrefabs = new GameObject().AddComponent<PlayerBox>();
			_factory.Init();
		}

		[Test]
		public void CreateBox()
		{
			var system = new PlayerBoxComponentCreatingSystem(_contexts, _factory);
			var entity = _contexts.game.CreateEntity();

			var player = new GameObject().AddComponent<Player>();
			player.PlayerId = 1;
			entity.AddPlayer(player);

			system.Initialize();

			Assert.AreEqual(_factory.AllContainers[1], _contexts.game.GetEntities(GameMatcher.PlayerBox).First().playerBox.BoxObject);
		}
	}
}

