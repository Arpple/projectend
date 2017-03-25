using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using End.Game;
using Entitas;
using System.Linq;

namespace End.Test
{
	public class TestStartingCardSystem
	{
		private Contexts _contexts;
		private CardSetting _setting;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			_setting = TestHelper.GetGameSetting().DeckSetting.CardSetting;
		}

		[Test]
		public void CreateCardForAllPlayer()
		{
			var system = new StartingCardSystem(_contexts, _setting);

			_setting.StartCardCount = 1;

			2.Loop((i) => {
				var obj = new GameObject();
				var p = obj.AddComponent<Player>();
				p.PlayerId = (short)i;
				_contexts.game.CreateEntity().AddPlayer(p);
				
				var card = _contexts.game.CreateEntity();
				card.AddCard((short)i, Card.Move);
				card.AddPlayerCard(0);
			});

			system.Initialize();

			foreach (var p in _contexts.game.GetEntities(GameMatcher.Player))
			{
				Assert.AreEqual(1, _contexts.gameEvent.GetEntities(GameEventMatcher.EventMoveCard)
					.Where(c => c.eventMoveCard.TargetPlayerId == p.player.PlayerId)
					.Count()
				);
			}
		}
	}
}
