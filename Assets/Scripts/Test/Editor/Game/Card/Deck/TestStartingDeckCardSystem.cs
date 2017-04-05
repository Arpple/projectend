using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Game;
using Entitas;
using System.Linq;

namespace Test.System
{
	public class TestStartingDeckCardSystem : ContextsTest
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
			var system = new StartingDeckCardSystem(_contexts, _setting);

			_setting.StartCardCount = 1;

			2.Loop((i) => {
				_contexts.game.CreatePlayerEntity((short)(i + 1));
				
				var card = _contexts.game.CreateEntity();
				card.AddGameCard((short)i, Card.Move);
				card.isGameDeckCard = true;
			});

			system.Initialize();

			foreach (var p in _contexts.game.GetEntities(GameMatcher.GamePlayer))
			{
				Assert.AreEqual(1, _contexts.gameEvent.GetEntities(GameEventMatcher.GameEventMoveCard)
					.Where(c => c.gameEventMoveCard.TargetPlayerEntity == p)
					.Count()
				);
			}
		}
	}
}
