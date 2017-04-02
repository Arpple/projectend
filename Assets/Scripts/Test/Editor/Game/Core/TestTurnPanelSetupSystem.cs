using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using End.Game;
using End.Game.UI;
using System.Collections.Generic;

namespace End.Test.System
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

			var ch = _contexts.game.CreateEntity();
			ch.AddCharacter(Character.LastBoss);
			ch.AddUnitIcon(sprite);
			ch.AddUnit(0, ch);

			_contexts.game.SetPlayingOrder(new List<GameEntity>() { ch });

			system.Initialize();

			Assert.AreEqual(1, _panel.TurnNodes.Count);
			Assert.AreEqual(sprite, _panel.TurnNodes[0].IconImage.sprite);
		}
	}
}