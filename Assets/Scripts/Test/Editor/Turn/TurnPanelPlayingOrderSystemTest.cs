using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Test.TurnTest
{
	public class TurnPanelPlayingOrderSystemTest : ContextsTest
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

			_systems.Add(new TurnPanelPlayingOrderSystem(_contexts, _panel));
		}

		[Test]
		public void Execute_PlayingOrder_NodeOrderByPlayingOrder()
		{
			var p1 = CreatePlayerEntity(1);
			var p2 = CreatePlayerEntity(2);
			p1.AddTurnNode(_panel.CreateTurnNode());
			p2.AddTurnNode(_panel.CreateTurnNode());

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