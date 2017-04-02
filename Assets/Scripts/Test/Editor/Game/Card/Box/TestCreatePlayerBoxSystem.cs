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
		private BoxContainer _container;

		[SetUp]
		public void Init()
		{
			var obj = new GameObject();
			_container = obj.AddComponent<BoxContainer>();
			_container.PlayerBoxPrefabs = new GameObject().AddComponent<PlayerBox>();
			_container.Init();
		}

		[Test]
		public void CreateBox()
		{
			var system = new CreatePlayerBoxSystem(_contexts, _container);
			var entity = _contexts.game.CreateEntity();

			var player = new GameObject().AddComponent<Player>();
			player.PlayerId = 1;
			entity.AddPlayer(player);

			system.Initialize();

			Assert.AreEqual(_container.PlayerBoxs[1], _contexts.game.GetEntities(GameMatcher.PlayerBox).First().playerBox.BoxObject);
		}
	}
}

