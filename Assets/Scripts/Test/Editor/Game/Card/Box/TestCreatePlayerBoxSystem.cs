using UnityEngine;
using NUnit.Framework;
using Game;
using Game.UI;
using System.Linq;
using Entitas;

namespace Test.System
{
	public class TestCreatePlayerBoxSystem : ContextsTest
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
			var system = new CreatePlayerBoxSystem(_contexts, _factory);
			var entity = _contexts.game.CreateEntity();

			var player = new GameObject().AddComponent<Player>();
			player.PlayerId = 1;
			entity.AddGamePlayer(player);

			system.Initialize();

			Assert.AreEqual(_factory.AllContainers[1], _contexts.game.GetEntities(GameMatcher.GamePlayerBox).First().gamePlayerBox.BoxObject);
		}
	}
}

