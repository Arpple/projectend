using UnityEngine;
using NUnit.Framework;
using End.Game;
using End.Game.UI;

namespace End.Test.System
{
	public class TestPlayerBoxCardSystem : ContextsTest
	{
		private GameEntity _player;

		[SetUp]
		public void Init()
		{
			_player = TestHelper.CreatePlayerEntity(_contexts.game, 1);
			var box = new GameObject().AddComponent<PlayerBox>();
			box.Init();
			_player.AddPlayerBox(box);

			var deck = new GameObject().AddComponent<PlayerDeck>();
			deck.Init();
			_player.AddPlayerDeck(deck);
		}

		[Test]
		public void InBoxComponentAdd()
		{
			var system = new PlayerBoxCardSystem(_contexts);

			var card = _contexts.game.CreateEntity();
			card.AddPlayerCard(_player);
			card.isDeckCard = true;
			card.AddView(new GameObject());
			card.AddInBox(0);

			system.Execute();

			Assert.AreEqual(_player.playerBox.BoxObject.Content, card.view.GameObject.transform.parent.gameObject);
		}

		[Test]
		public void InBoxComponentRemove()
		{
			var system = new PlayerBoxCardSystem(_contexts);

			var card = _contexts.game.CreateEntity();
			card.AddPlayerCard(_player);
			card.isDeckCard = true;
			card.AddView(new GameObject());
			card.AddInBox(0);
			card.RemoveInBox();

			system.Execute();

			Assert.AreEqual(_player.playerDeck.PlayerDeckObject.Content, card.view.GameObject.transform.parent.gameObject);
		}
	}

}

