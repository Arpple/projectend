using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Test;
using Entitas;

namespace Game.Test
{
	public class StartTurnDrawSystemTest : ContextsTest
	{
		const int TEST_DRAW_COUNT = 1;

		[SetUp]
		public void Init()
		{
			var setting = new DeckSetting()
			{
				StartTurnDrawCount = TEST_DRAW_COUNT
			};

			_systems.Add(new StartTurnDrawSystem(_contexts, setting));
		}

		private void CreateDeckCard(int count)
		{
			count.Loop(
				() =>
				{
					var card = _contexts.card.CreateCard(Card.Test);
					card.isGameDeckCard = true;
				}
			);
		}

		[Test]
		public void Execute_LocalTurn_CreateCardEvent()
		{
			var p = TestHelper.CreatePlayerEntity(_contexts.game, 1);
			p.isGameLocal = true;
			p.isGamePlaying = true;

			CreateDeckCard(TEST_DRAW_COUNT);

			_systems.Execute();

			var events = _contexts.gameEvent.GetEntities(GameEventMatcher.GameEventMoveCard);
			Assert.AreEqual(TEST_DRAW_COUNT, events.Length);
			
			foreach(var e in events)
			{
				Assert.AreEqual(p, e.gameEventMoveCard.TargetPlayerEntity);
			}
		}

		[Test]
		public void Execute_NotLocalTurn_NoEventCreated()
		{
			var p = _contexts.game.CreateEntity();
			p.isGamePlaying = true;

			CreateDeckCard(TEST_DRAW_COUNT);

			_systems.Execute();

			var events = _contexts.gameEvent.GetEntities(GameEventMatcher.GameEventMoveCard);
			Assert.IsEmpty(events);
		}
	}
}
