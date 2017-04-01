using UnityEngine;
using NUnit.Framework;
using End.Game;
using End.Game.UI;
using System.Linq;
using Entitas;

namespace End.Test
{
	public class TestOnDeadBoxSystem
	{
		private Contexts _contexts;
		private GameEntity _ownerPlayer;
		private GameEntity _unit;

		private class TestOnDeadAbility : Ability, IOnDeadAbility
		{
			public void OnDead(GameEntity deadEntity)
			{
				deadEntity.hitpoint.HitPoint += 1;
			}
		}

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();

			_ownerPlayer = _contexts.game.CreateEntity();
			_ownerPlayer.AddPlayer(new GameObject().AddComponent<Player>());

			_unit = _contexts.game.CreateEntity();
			_unit.AddUnit(0, _ownerPlayer);
		}

		[Test]
		public void CallOnDeadAbilityFromBox()
		{
			var system = new OnDeadBoxSystem(_contexts);
			_unit.AddHitpoint(0);

			var box = new GameObject().AddComponent<PlayerBox>();
			_ownerPlayer.AddPlayerBox(box);

			var card = _contexts.game.CreateEntity();
			card.AddCard(0, Card.Potion);
			card.AddPlayerCard(_ownerPlayer);
			card.AddInBox(0);
			card.AddAbility("", new TestOnDeadAbility());

			system.Execute();

			var gameEvent = _contexts.gameEvent.GetEntities(GameEventMatcher.EventUseCardOnUnit).First();
			Assert.IsNotNull(gameEvent);
			Assert.AreEqual(_unit, gameEvent.eventUseCardOnUnit.UserEntity);
			Assert.AreEqual(card, gameEvent.eventUseCardOnUnit.CardEnttiy);
			Assert.AreEqual(_unit, gameEvent.eventUseCardOnUnit.TargetEnttiy);
		}
	}
}