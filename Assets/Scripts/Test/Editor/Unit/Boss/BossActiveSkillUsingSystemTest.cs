﻿using NUnit.Framework;

namespace Test.UnitTest.BossTest
{
	public class BossActiveSkillUsingSystemTest : ContextsTest
	{
		protected static bool _isAbilityCalled;

		private class TestAbility : SelfActiveAbility
		{
			public override void OnTargetSelected(UnitEntity caster, UnitEntity target)
			{
				_isAbilityCalled = true;
			}
		}

		GameEntity _player;

		[SetUp]
		public void Init()
		{
			_isAbilityCalled = false;

			_systems.Add(new BossActiveSkillUsingSystem(_contexts));

			_player = CreatePlayerEntity(-1);
			_player.isBossPlayer = true;

			var unit = _contexts.unit.CreateEntity();
			unit.AddOwner(_player);

			var card = _contexts.card.CreateEntity();
			card.AddSkillCard(SkillCard.Monolith_JudgementLight);
			card.AddAbility(new TestAbility());
			card.AddOwner(_player);
		}

		[Test]
		public void Execute_BossPlayerIsPlaying_BossSelfActiveAbilityCardCalled()
		{
			_player.isPlaying = true;

			_systems.Execute();

			Assert.IsTrue(_isAbilityCalled);
		}
	}
}
