using UnityEngine;
using NUnit.Framework;
using End.Game;

namespace End.Test
{
	public class TestEventMoveCard
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			GameController.IsTest = true;
		}

		[Test]
		public void CreateEvent()
		{
			var card = _contexts.game.CreateEntity();
			card.AddCard(1, Card.Move);
			card.AddPlayerDeckCard(1);

			EventMoveCard.MoveCard(card, 2);

			var eventEntity = _contexts.gameEvent.GetEntities();

			Assert.AreEqual(1, eventEntity.Length);
			Assert.IsTrue(eventEntity[0].hasEventMoveCard);

			var e = eventEntity[0].eventMoveCard;
			Assert.AreEqual(card, e.CardEntity);
			Assert.AreEqual(2, e.TargetPlayerId);
		}

		[Test]
		public void SystemReplacePosition()
		{
			var system = new EventMoveCardSystem(_contexts);

			var card = _contexts.game.CreateEntity();
			card.AddCard(1, Card.Move);
			card.AddPlayerDeckCard(1);

			EventMoveCard.MoveCard(card, 2);

			system.Execute();

			Assert.AreEqual(2, card.playerDeckCard.CurrentOwnerId);
		}
	}

}
