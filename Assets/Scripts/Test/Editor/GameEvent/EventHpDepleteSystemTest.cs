using System;
using Network;
using NUnit.Framework;
using UnityEngine;

namespace Test.EventTest
{
	public class EventHpDepleteSystemTest : ContextsTest
	{
		private GameEntity _ownerPlayer;
		private UnitEntity _unit;

		private class TestOnDeadAbility : Ability, IOnDeadAbility
		{
			private Action _action;

			public TestOnDeadAbility(Action action)
			{
				_action = action;
			}

			public void OnDead(UnitEntity deadEntity)
			{
				_action();
			}
		}

		private class TestReviveAbility : Ability, IReviveAbility 
		{
			private Action _action;

			public TestReviveAbility(Action action)
			{
				_action = action;
			}

			public void OnDead(UnitEntity deadEntity)
			{
				_action();
				deadEntity.hitpoint.Value = 1;
			}
		}

		[SetUp]
		public void Init()
		{
			_ownerPlayer = _contexts.game.CreateEntity();
			_ownerPlayer.AddPlayer(new GameObject().AddComponent<Player>());

			_unit = _contexts.unit.CreateEntity();
			_unit.AddOwner(_ownerPlayer);

			_systems.Add(new EventHpDepleteSystem(_contexts));
		}

		[Test]
		public void Execute_UnitHaveOnDeadSkill_SkillUsed()
		{
			_unit.AddHitpoint(0);

			bool isAbilityUsed = false;
			CreateSkillCard(new TestOnDeadAbility(() => isAbilityUsed = true));

			_systems.Execute();
			Assert.IsTrue(isAbilityUsed);
		}

		[Test]
		public void Execute_UnitOwnerHaveOnDeadCardInBox_CardUsed()
		{
			_unit.AddHitpoint(0);

			bool isAbilityUsed = false;
			CreateBoxCard(new TestOnDeadAbility(() => isAbilityUsed = true), 1);

			_systems.Execute();
			Assert.IsTrue(isAbilityUsed);
		}

		[Test]
		public void Execute_UnitHaveReviveSkill_SkillUsed()
		{
			_unit.AddHitpoint(0);

			bool isAbilityUsed = false;
			CreateSkillCard(new TestReviveAbility(() => isAbilityUsed = true));

			_systems.Execute();
			Assert.IsTrue(isAbilityUsed);
			Assert.IsTrue(_unit.hitpoint.Value > 0);
		}

		[Test]
		public void Execute_UnitOwnerHaveReviveCardInBox_FirstCardUsed()
		{
			_unit.AddHitpoint(0);

			bool isCard1Used = false;
			bool isCard2Used = false;

			var card1 = CreateBoxCard(new TestReviveAbility(() => isCard1Used = true), 1);
			var card2 = CreateBoxCard(new TestReviveAbility(() => isCard2Used = true), 2);

			_systems.Execute();
			Assert.IsTrue(isCard1Used);
			Assert.IsFalse(isCard2Used);
			Assert.IsTrue(_unit.hitpoint.Value > 0);
		}

		private CardEntity CreateBoxCard(Ability ability, int index)
		{
			var card = _contexts.card.CreateEntity();
			card.AddDeckCard(DeckCard.Potion);
			card.AddOwner(_ownerPlayer);
			card.AddInBox(index);
			card.AddAbility(ability);

			return card;
		}

		private CardEntity CreateSkillCard(Ability ability)
		{
			var card = _contexts.card.CreateEntity();
			card.AddSkillCard(SkillCard.Monolith_JudgementLight);
			card.AddOwner(_ownerPlayer);
			card.AddAbility(ability);

			return card;
		}
	}
}