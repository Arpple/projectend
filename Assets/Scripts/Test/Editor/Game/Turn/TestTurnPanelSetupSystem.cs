using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Test.GameTest.TurnTest
{
	public class TestTurnPanelSetupSystem : ContextsTest
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
		}

		[Test]
		public void CreateNodeAndAddToTurnPanel()
		{
			var system = new TurnPanelSetupSystem(_contexts, _panel);

			var sprite = Resources.Load<Sprite>("Test/Editor/Sprite");

			var player = _contexts.game.CreateEntity();

			var ch = _contexts.unit.CreateEntity();
			ch.AddCharacter(Character.LastBoss);
			ch.AddUnitIcon(sprite);
			ch.AddOwner(player);

			_contexts.game.SetPlayingOrder(new List<GameEntity>() { player });

			system.Initialize();

			Assert.AreEqual(1, _panel.TurnNodes.Count);
			Assert.AreEqual(sprite, _panel.TurnNodes[0].IconImage.sprite);
		}
	}
}