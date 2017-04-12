using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Test.GameTest.TurnTest
{
	public class TurnPanelSystemTest : ContextsTest
	{
		private TurnPanel _panel;

		[SetUp]
		public void Init()
		{
			_panel = new GameObject().AddComponent<TurnPanel>();
			
			var node = new GameObject().AddComponent<TurnNode>();
			node.IconImage = new GameObject().AddComponent<Image>();

			_panel.TurnNodePrefabs = node;
			_panel.TurnNodes = new List<TurnNode>();
			_panel.TurnNodeParent = new GameObject().transform;

			_systems.Add(new TurnPanelSystem(_contexts, _panel));
		}

		[Test]
		public void Initialize_PlayerEntityCreated_TurnNodeCreated()
		{
			var player = CreatePlayerEntity(1);
			_contexts.game.SetPlayingOrder(new List<GameEntity>() { player });

			_systems.Initialize();

			Assert.AreEqual(1, _panel.TurnNodes.Count);
			Assert.IsTrue(player.hasTurnNode);
			Assert.AreEqual(_panel.TurnNodes[0], player.turnNode.Object);
		}

		[Test]
		public void Initialize_PlayerEntitiesCreated_TurnNodesCreatedOrderByPlayOrder()
		{
			var p1 = CreatePlayerEntity(1);
			var p2 = CreatePlayerEntity(2);
			_contexts.game.SetPlayingOrder(new List<GameEntity>
			{
				p1, p2
			});

			_systems.Initialize();

			Assert.AreEqual(p1.turnNode.Object, _panel.TurnNodes[0]);
			Assert.AreEqual(p2.turnNode.Object, _panel.TurnNodes[1]);
		}

		[Test]
		public void Execute_PlayOrderChange_TurnNodeOrderChange()
		{
			var p1 = CreatePlayerEntity(1);
			var p2 = CreatePlayerEntity(2);
			_contexts.game.SetPlayingOrder(new List<GameEntity>
			{
				p1, p2
			});

			_systems.Initialize();

			_contexts.game.ReplacePlayingOrder(new List<GameEntity>
			{
				p2, p1
			});

			_systems.Execute();

			Assert.AreEqual(p2.turnNode.Object, _panel.TurnNodes[0]);
			Assert.AreEqual(p1.turnNode.Object, _panel.TurnNodes[1]);
		}
	}
}