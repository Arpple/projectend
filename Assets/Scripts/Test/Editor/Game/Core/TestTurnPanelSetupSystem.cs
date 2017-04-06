using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using Game;
using Game.UI;
using System.Collections.Generic;

namespace Test.System
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
			ch.AddGameCharacter(Character.LastBoss);
			ch.AddGameUnitIcon(sprite);
			ch.AddGameUnit(0, player);

			_contexts.game.SetGamePlayingOrder(new List<GameEntity>() { player });

			system.Initialize();

			Assert.AreEqual(1, _panel.TurnNodes.Count);
			Assert.AreEqual(sprite, _panel.TurnNodes[0].IconImage.sprite);
		}
	}
}