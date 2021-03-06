﻿using NUnit.Framework;


namespace Test.CardTest.AbilityTest
{
	public class TestAbilityRecover : ActiveAbilityTest<UnitEntity>
	{
		protected override Ability CreateAbility()
		{
			return new AbilityRecover();
		}

		protected override UnitEntity SetupTarget()
		{
			var entity = _contexts.unit.CreateEntity();
			entity.AddUnitStatus(10, 1, 1, 1, 1);
			entity.AddHitpoint(0);
			entity.isDead = true;

			return entity;
		}

		[Test]
		public void RecoverAndReviveTarget()
		{
			_activeAbility.OnTargetSelected(_caster, _target);

			Assert.IsFalse(_target.isDead);
			Assert.AreEqual(1, _target.hitpoint.Value);
		}

		[Test]
		public void PassiveReviveEffect()
		{
			var a = (IReviveAbility)_ability;
			a.OnDead(_target);

			Assert.IsFalse(_target.isDead);
			Assert.AreEqual(1, _target.hitpoint.Value);
		}
	}
}
