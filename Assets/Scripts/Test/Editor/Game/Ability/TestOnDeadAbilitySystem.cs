using UnityEngine;
using NUnit.Framework;
using Game;
using Game.UI;
using System.Linq;
using Entitas;
using System;

namespace Test.System
{
	public class TestOnDeadAbilitySystem : ContextsTest
	{
		private GameEntity _ownerPlayer;
		private GameEntity _unit;

		private class TestOnDeadAbility : Ability, IOnDeadAbility
		{
			public void OnDead(GameEntity deadEntity)
			{
				Assert.Pass();
			}
		}

		[SetUp]
		public void Init()
		{
			_ownerPlayer = _contexts.game.CreateEntity();
			_ownerPlayer.AddPlayer(new GameObject().AddComponent<Player>());

			_unit = _contexts.game.CreateEntity();
			_unit.AddUnit(0, _ownerPlayer);
		}

		[Test]
		public void CallOnDeadAbilityFromBox()
		{
			var system = new OnDeadAbilitySystem(_contexts);
			_unit.AddHitpoint(0);

			var box = new GameObject().AddComponent<PlayerBox>();
			_ownerPlayer.AddPlayerBox(box);

			var card = _contexts.game.CreateEntity();
			card.AddCard(0, Card.Potion);
			card.AddPlayerCard(_ownerPlayer);
			card.AddInBox(0);
			card.AddAbility("", new TestOnDeadAbility());

			system.Execute();

			//fail if ability not called
			Assert.Fail();
		}
	}
}