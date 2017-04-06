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
				
			}
		}

		[SetUp]
		public void Init()
		{
			_ownerPlayer = _contexts.game.CreateEntity();
			_ownerPlayer.AddGamePlayer(new GameObject().AddComponent<Player>());

			_unit = _contexts.game.CreateEntity();
			_unit.AddGameUnit(0, _ownerPlayer);

			_systems.Add(new OnDeadAbilitySystem(_contexts));
		}

		[Test]
		public void CallOnDeadAbilityFromBox()
		{
			_unit.AddGameHitpoint(0);

			var box = new GameObject().AddComponent<PlayerBox>();
			_ownerPlayer.AddGamePlayerBox(box);

			var card = _contexts.game.CreateEntity();
			card.AddGameCard(Card.Potion);
			card.AddGamePlayerCard(_ownerPlayer);
			card.AddGameInBox(0);
			card.AddGameAbility("", new TestOnDeadAbility());
			card.isGameDeckCard = true;

			_systems.Execute();
			Assert.Pass();
		}
	}
}