using Entitas;
using NUnit.Framework;

namespace Test.CardTest.DeckTest
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
					_contexts.card.CreateDeckCard(DeckCard.Move);
				}
			);
		}

		[Test]
		public void Execute_LocalTurn_CreateCardEvent()
		{
			var p = TestHelper.CreatePlayerEntity(_contexts.game, 1);
			p.isLocal = true;
			p.isPlaying = true;

			CreateDeckCard(TEST_DRAW_COUNT);

			_systems.Execute();

			var events = _contexts.gameEvent.GetEntities(GameEventMatcher.EventMoveDeckCard);
			Assert.AreEqual(TEST_DRAW_COUNT, events.Length);
			
			foreach(var e in events)
			{
				Assert.AreEqual(p, e.eventMoveDeckCard.TargetPlayerEntity);
			}
		}

		[Test]
		public void Execute_NotLocalTurn_NoEventCreated()
		{
			var p = _contexts.game.CreateEntity();
			p.isPlaying = true;

			CreateDeckCard(TEST_DRAW_COUNT);

			_systems.Execute();

			var events = _contexts.gameEvent.GetEntities(GameEventMatcher.EventMoveDeckCard);
			Assert.IsEmpty(events);
		}
	}
}
