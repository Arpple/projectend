using UnityEngine;
using NUnit.Framework;
using End.Game;

namespace End.Test
{
	public class TestEventMoveCard
	{
		private Contexts _contexts;
		private GameEntity _card;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			GameController.IsTest = true;

			_card = _contexts.game.CreateEntity();
			_card.AddCard(1, Card.Move);
			_card.AddPlayerCard(1);
		}

		[Test]
		public void CreateEvent()
		{
			EventMoveCard.MoveCardToPlayer(_card, 2);

			var eventEntity = _contexts.gameEvent.GetEntities();

			Assert.AreEqual(1, eventEntity.Length);
			Assert.IsTrue(eventEntity[0].hasEventMoveCard);

			var e = eventEntity[0].eventMoveCard;
			Assert.AreEqual(_card, e.CardEntity);
			Assert.AreEqual(2, e.TargetPlayerId);
		}

		[Test]
		public void MoveToPlayer()
		{
			var system = new EventMoveCardSystem(_contexts);

			EventMoveCard.MoveCardToPlayer(_card, 2);

			system.Execute();

			Assert.AreEqual(2, _card.playerCard.CurrentOwnerId);
		}

		[Test]
		public void MoveInToBox()
		{
			var system = new EventMoveCardSystem(_contexts);

			EventMoveCard.MoveCardInToBox(_card);

			system.Execute();

			Assert.AreEqual(1, _card.playerCard.CurrentOwnerId);
			Assert.IsTrue(_card.hasInBox);
		}

		[Test]
		public void MoveOutFromBox()
		{
			var system = new EventMoveCardSystem(_contexts);

			_card.AddInBox(0);

			EventMoveCard.MoveCardOutFromBox(_card);

			system.Execute();

			Assert.AreEqual(1, _card.playerCard.CurrentOwnerId);
			Assert.IsFalse(_card.hasInBox);
		}

		[Test]
		public void MoveToShareDeck()
		{
			var system = new EventMoveCardSystem(_contexts);

			EventMoveCard.MoveCardToShareDeck(_card);

			system.Execute();

			Assert.IsFalse(_card.hasPlayerCard);
		}
	}

}
