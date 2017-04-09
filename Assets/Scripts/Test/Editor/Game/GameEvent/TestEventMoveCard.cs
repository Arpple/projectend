using UnityEngine;
using NUnit.Framework;
using Game;

namespace Test.Event
{
	public class TestEventMoveCard : ContextsTest
	{
		[Test]
		public void CreateEvent()
		{
			var p1 = CreatePlayerEntity(1);
			var p2 = CreatePlayerEntity(2);

			var card = _contexts.card.CreateEntity();
			card.AddGameCard(Card.Move);
			card.AddGameOwner(p1);

			EventMoveCard.MoveCardToPlayer(card, p2);

			var eventEntity = _contexts.gameEvent.GetEntities();

			Assert.AreEqual(1, eventEntity.Length);
			Assert.IsTrue(eventEntity[0].hasGameEventMoveCard);

			var e = eventEntity[0].gameEventMoveCard;
			Assert.AreEqual(card, e.CardEntity);
			Assert.AreEqual(p2, e.TargetPlayerEntity);
		}

		[Test]
		public void MoveToPlayer()
		{
			var system = new EventMoveCardSystem(_contexts);

			var p1 = CreatePlayerEntity(1);
			var p2 = CreatePlayerEntity(2);

			var card = _contexts.card.CreateEntity();
			card.AddGameCard(Card.Move);
			card.AddGameOwner(p1);


			EventMoveCard.MoveCardToPlayer(card, p2);

			system.Execute();

			Assert.AreEqual(p2, card.gameOwner.Entity);
		}

		[Test]
		public void MoveInToBox()
		{
			var system = new EventMoveCardSystem(_contexts);

			var p1 = CreatePlayerEntity(1);

			var card = _contexts.card.CreateEntity();
			card.AddGameCard(Card.Move);
			card.AddGameOwner(p1);

			EventMoveCard.MoveCardInToBox(card);

			system.Execute();

			Assert.AreEqual(p1, card.gameOwner.Entity);
			Assert.IsTrue(card.hasGameInBox);
		}

		[Test]
		public void MoveOutFromBox()
		{
			var system = new EventMoveCardSystem(_contexts);

			var p1 = CreatePlayerEntity(1);

			var card = _contexts.card.CreateEntity();
			card.AddGameCard(Card.Move);
			card.AddGameOwner(p1);
			card.AddGameInBox(0);

			EventMoveCard.MoveCardOutFromBox(card);

			system.Execute();

			Assert.AreEqual(p1, card.gameOwner.Entity);
			Assert.IsFalse(card.hasGameInBox);
		}

		[Test]
		public void MoveToShareDeck()
		{
			var system = new EventMoveCardSystem(_contexts);

			var p1 = CreatePlayerEntity(1);
			var card = _contexts.card.CreateEntity();
			card.AddGameCard(Card.Move);
			card.AddGameOwner(p1);

			EventMoveCard.MoveCardToShareDeck(card);

			system.Execute();

			Assert.IsFalse(card.hasGameOwner);
		}
	}

}
