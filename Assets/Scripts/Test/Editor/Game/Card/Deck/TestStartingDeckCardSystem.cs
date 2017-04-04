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
				card.AddCard((short)i, Card.Move);
			});

			system.Initialize();

			foreach (var p in _contexts.game.GetEntities(GameMatcher.Player))
			{
				Assert.AreEqual(1, _contexts.gameEvent.GetEntities(GameEventMatcher.EventMoveCard)
					.Where(c => c.eventMoveCard.TargetPlayerEntity == p)
					.Count()
				);
			}
		}
	}
}
