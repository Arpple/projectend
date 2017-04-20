using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Test.TurnTest
{
	public class TurnNodeCreatingSystemTest : ContextsTest
	{
		private TurnPanel _panel;

		[SetUp]
		public void Init()
		{
			_panel = new GameObject().AddComponent<TurnPanel>();
			var node = new GameObject().AddComponent<TurnNode>();
			node.IconImage = new GameObject().AddComponent<Image>();
			node.CurrentTurnIndicator = new GameObject();

			_panel.TurnNodePrefabs = node;
			_panel.TurnNodes = new List<TurnNode>();
			_panel.TurnNodeParent = new GameObject().transform;

			_systems.Add(new TurnNodeCreatingSystem(_contexts, _panel));
		}

		[Test]
		public void Execute_PlayerEntity_TurnNodeCreted()
		{
			var p1 = CreatePlayerEntity(1);

			var unit = _contexts.unit.CreateEntity();
			unit.AddOwner(p1);

			_systems.Execute();

			Assert.IsTrue(p1.hasTurnNode);
			Assert.AreEqual(1, _panel.TurnNodes.Count);
			Assert.AreEqual(_panel.TurnNodes[0], p1.turnNode.Object);
		}
	}
}
