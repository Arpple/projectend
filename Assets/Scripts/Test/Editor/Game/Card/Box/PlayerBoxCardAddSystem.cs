using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using End.Game;
using End.Game.UI;

namespace End.Test
{
	public class TestPlayerBoxCardAddSystem
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

		[Test]
		public void CardViewObjectMovedToBoxObject()
		{
			var system = new PlayerBoxCardAddSystem(_contexts);

			var player = new GameObject().AddComponent<Player>();
			player.PlayerId = 1;

			var container = _contexts.game.CreateEntity();
			container.AddPlayer(player);
			var box = new GameObject().AddComponent<PlayerBox>();
			box.Init();
			container.AddPlayerBox(box);

			var card = _contexts.game.CreateEntity();
			card.AddPlayerCard(container);
			card.isDeckCard = true;
			card.AddView(new GameObject());
			card.AddInBox(0);

			system.Execute();

			Assert.AreEqual(container.playerBox.BoxObject.Content, card.view.GameObject.transform.parent.gameObject);
		}
	}

}

