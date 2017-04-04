using UnityEngine;
using NUnit.Framework;
using End.Game;
using End.Game.UI;
using System.Linq;
using Entitas;

namespace End.Test.System
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
			entity.AddPlayer(player);

			system.Initialize();

			Assert.AreEqual(_factory.AllContainers[1], _contexts.game.GetEntities(GameMatcher.PlayerBox).First().playerBox.BoxObject);
		}
	}
}

