using System.Linq;
using Entitas;
using NUnit.Framework;

namespace Test.CardTest.DeckTest
{
	public class TestStartDeckCardDrawingSystem : ContextsTest
	{
		private DeckSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting.DeckSetting;
		}

		[Test]
		public void CreateCardForAllPlayer()
		{
			var system = new StartDeckCardDrawingSystem(_contexts, _setting);
			_contexts.game.SetRound(1);

			_setting.StartCardCount = 1;

			2.Loop((i) => {
				CreatePlayerEntity(i + 1);
				
				var card = _contexts.card.CreateEntity();
				card.AddDeckCard(DeckCard.Move);
			});

			system.Execute();

			foreach (var p in _contexts.game.GetEntities(GameMatcher.Player))
			{
				Assert.AreEqual(1, _contexts.gameEvent.GetEntities(GameEventMatcher.EventMoveDeckCard)
					.Where(c => c.eventMoveDeckCard.TargetPlayerEntity == p)
					.Count()
				);
			}
		}
	}
}
